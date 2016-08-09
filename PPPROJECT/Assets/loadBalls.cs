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
		jsonString = File.ReadAllText (Application.dataPath + "/data_out.json");
		Debug.Log (jsonString);
        
		itemData = JsonMapper.ToObject (jsonString);
        
		int n = itemData.Count;
		//GameObject myObject = Resources.Load("Ball") as GameObject;
		for (int i = 0; i < n; i++) {
			s = GameObject.Instantiate (Resources.Load ("Orb")) as GameObject;
			int offset = int.Parse (""+itemData [i] ["last_ddl"])-1449873761;
			int max = 1468002432-1449873761;
			float f = 2f*offset/max;
			s.transform.position = new Vector3 ((Random.value * 4) - 2f, 
				f, 
				(Random.value * 4) - 2f);
			s.name = "item" + itemData [i] ["id"] + ":" + itemData [i] ["database_name"];
			GameObject child = s.transform.FindChild ("Text").gameObject;
			child.GetComponent<TextMesh> ().text =
				"\n"+itemData[i]["object_type"]+
				"\n"+itemData[i]["partitions"]+
				"\n"+itemData[i]["table_name"];
					
			Color c;
			if (itemData [i] ["object_type"] + "" == "internal_table") {
				c = Color.green;
			} else if (itemData [i] ["object_type"] + "" == "view") {
				c = Color.blue;
			} else if (itemData [i] ["object_type"] + "" == "external_table") {
				c = Color.red;
			} else {
				c = Color.gray;
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
