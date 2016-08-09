using UnityEngine;
using System.Collections;

public class explode : MonoBehaviour {
	public Vector3 startPosition;

	// Use this for initialization
	void Start () {

		startPosition = transform.position;

		foreach (Transform child in transform) {
			Vector3 endPosition = new Vector3 (Random.value * 2, Random.value * 2, Random.value * 2);

			Vector3 newPosition = Vector3.Lerp (startPosition, endPosition, Time.time);

			child.position = endPosition;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
