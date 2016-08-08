using UnityEngine;
using System.Collections;
using System.IO;
using LitJson;
using System.Data;
using Mono.Data.SqliteClient;

public class GameScript : MonoBehaviour {
	private GameObject s;
	private string jsonString;
	private JsonData itemData;

	private IDbConnection dbConn;
	private IDbCommand dbCommand;
	private IDataReader dataReader;

//	public Transform startMarker;
//	public Transform endMarker;
//	public float speed = 1.0F;
//	private float startTime;
//	private float journeyLength;

	// Use this for initialization
	void Start () {
		// read from database
		Debug.Log(Application.dataPath);
		string connStr = "URI=File:"+Application.dataPath+"/test_1.db";


		dbConn = new SqliteConnection (connStr);

		dbConn.Open();

		string query = "select * from user";

		dbCommand = dbConn.CreateCommand();
		dbCommand.CommandText = query;
		dataReader = dbCommand.ExecuteReader ();

		while (dataReader.Read ()) {
			Debug.Log(dataReader.GetString(1) + " " );
		}
			
		dbConn.Close();



//		jsonString = File.ReadAllText(Application.dataPath + "/MOCK_DATA.json");
//		Debug.Log (jsonString);
//
//		itemData = JsonMapper.ToObject (jsonString);
//
//		int n = itemData.Count;
//
//		for (int i = 0; i < n; i++){
//			s = GameObject.CreatePrimitive(PrimitiveType.Sphere);
//			s.transform.position = new Vector3 ((Random.value*10)-5, (Random.value*10)-5, 0F);
//			s.name = "item" + itemData[i]["id"] + ":" +itemData[i]["first_name"];
//		}

//		startTime = Time.time;
//		journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
	}
	
	// Update is called once per frame
	void Update () {
//		float distCovered = (Time.time - startTime) * speed;
//		float fracJourney = distCovered / journeyLength;
//		transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
	}
}
