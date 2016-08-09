using UnityEngine;
using System.Collections;
using System.IO;
using LitJson;
using System.Data;
using Mono.Data.SqliteClient;
using System.Collections.Generic;

public class GameScript : MonoBehaviour
{
	private GameObject s;
	private string jsonString;
	private JsonData itemData;

	private IDbConnection dbConn;
	private IDbCommand dbCommand;
	private IDataReader dataReader;

	public Transform startPosition;
	public Transform endPosition;
	public List<Vector3> positions;
	public float startTime;
	public float totalDistanceToDestination;

	public List<GameObject> gameList;

	// Use this for initialization
	void Start ()
	{
		// read from database
//		Debug.Log(Application.dataPath);
//		string connStr = "URI=File:"+Application.dataPath+"/test_1.db";
//
//		dbConn = new SqliteConnection (connStr);
//
//		dbConn.Open();
//
//		string query = "select * from user_2";
//
//		dbCommand = dbConn.CreateCommand();
//		dbCommand.CommandText = query;
//		dataReader = dbCommand.ExecuteReader ();
//
//		while (dataReader.Read ()) {
//			Debug.Log(dataReader.GetString(1) + " " + dataReader.GetString(0));
//		}
//			
//		dbConn.Close();

		//Read data from json file
		jsonString = File.ReadAllText (Application.dataPath + "/MOCK_DATA.json");
		Debug.Log (jsonString);

		itemData = JsonMapper.ToObject (jsonString);

		int n = itemData.Count;
		positions = new List<Vector3> ();
		gameList = new List<GameObject> ();

		for (int i = 0; i < n; i++) {
			s = GameObject.CreatePrimitive (PrimitiveType.Sphere);
			s.transform.position = new Vector3 ((Random.value * 10) - 5, (Random.value * 10) - 5, 0F);

			//s.name = "item" + itemData[i]["id"] + ":" +itemData[i]["first_name"];
			s.name = itemData[i][1] + " ";
			Debug.Log (s.name);

			if (itemData [i].Count > 0) {
				Debug.Log (itemData [i].Count);
				for (int j = 0; j < itemData [i].Count; j++) {
					GameObject childSphere = GameObject.CreatePrimitive (PrimitiveType.Sphere);

					childSphere.transform.parent = s.transform;

					//SphereCollider childSphere = s.AddComponent(typeof(SphereCollider) )  as SphereCollider;

					//childSphere.transform.position = s.transform.position;
					
					positions.Add (new Vector3 (Random.value * 2, Random.value * 2, Random.value * 2));
				}
			}
			gameList.Add (s);
			Debug.Log ("counting children");

			foreach (GameObject game in gameList) {
				List<GameObject> children = lerpChildren (game.transform);

				Debug.Log (children.Count);
			}

			//use Coroutine instead of Update() to schedule movement

		}
		//StartCoroutine (MultipleLerp (1, positions));


		//for each gameObject in gameList, get all children, and make each child move


	}

	List<GameObject> lerpChildren(Transform parent){
		List<GameObject> children = new List<GameObject> ();

//		foreach (Transform child in parent) {
//			
//			children.Add (childSphere);
//
//		}
		return children;

	}

	IEnumerator MultipleLerp (float speed, List<Vector3> positions) {
		foreach (Vector3 position in positions) {
			Vector3 startPos = transform.position;
			float timer = 0f;
			while (timer <= 1f) {
				timer += Time.deltaTime * speed;
				Vector3 newPosition = Vector3.Lerp (startPos, position, timer);
				transform.position = newPosition;
				yield return new WaitForEndOfFrame ();
			}
			transform.position = position;
			startPos = position;
		}
		yield return false;
	}
		
	// Update is called once per frame
	void Update (){
		if(Input.GetKeyDown("space")){
			Debug.Log ("pressing space");
			MultipleLerp (1, positions);
		}
		
	}
}
