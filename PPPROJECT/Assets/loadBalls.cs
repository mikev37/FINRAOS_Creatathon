using UnityEngine;
using System.Collections;
using System.IO;
using LitJson;
using System.Data;
using Mono.Data.SqliteClient;

public class loadBalls : MonoBehaviour {
    private GameObject s;
    private string jsonString;
    private JsonData itemData;
    // Use this for initialization
    void Start () {
        		jsonString = File.ReadAllText(Application.dataPath + "/MOCK_DATA.json");
        		Debug.Log (jsonString);
        
        		itemData = JsonMapper.ToObject (jsonString);
        
        		int n = itemData.Count;
        		//GameObject myObject = Resources.Load("Ball") as GameObject;
        		for (int i = 0; i < n; i++){
                    s = GameObject.Instantiate(Resources.Load("Orb")) as GameObject;
            		s.transform.position = new Vector3 ((Random.value*10)-5, (Random.value*10)-5, 0F);
        			s.name = "item" + itemData[i]["id"] + ":" +itemData[i]["first_name"];
        		}
    }

    // Update is called once per frame
    void Update () {
	
	}
}
