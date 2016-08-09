using UnityEngine;
using System.Collections;
using System.IO;
using LitJson;
using System.Data;
using Mono.Data.SqliteClient;

public class loadBalls : MonoBehaviour
{
	private GameObject s;
	private string jsonString;
	private JsonData itemData;
	// Use this for initialization
	void Start ()
	{
		jsonString = File.ReadAllText (Application.dataPath + "/MOCK_DATA.json");
		Debug.Log (jsonString);
        
		itemData = JsonMapper.ToObject (jsonString);
        
		int n = itemData.Count;
		//GameObject myObject = Resources.Load("Ball") as GameObject;
		for (int i = 0; i < n; i++) {
			s = GameObject.Instantiate (Resources.Load ("Orb")) as GameObject;
			s.transform.position = new Vector3 ((Random.value * 3) - 1.5f, (Random.value * 2) - 1 + 1, (Random.value * 3) - 1.5f);
			s.name = "item" + itemData [i] ["id"] + ":" + itemData [i] ["first_name"];
			GameObject child = s.transform.FindChild ("Text").gameObject;
			child.GetComponent<TextMesh> ().text = " " + itemData [i] ["first_name"];
					
			Color c;
			if (i % 2 == 0) {
				c = Color.green;
			} else {
				c = Color.red;
			}
			Renderer r = s.GetComponent<Renderer> ();
			r.material.SetColor ("_SpecColor", c);
			r.material.SetColor ("_EmissionColor", c);
			s.GetComponent<Light> ().color = c;
		}
	}

	// Update is called once per frame
	void Update ()
	{
	
	}
}
