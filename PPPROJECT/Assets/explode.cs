using UnityEngine;
using System.Collections;

public class explode : MonoBehaviour {
	public Vector3 startPosition;
	public Vector3 endPosition;
	float startTime;
	float journeyLength;
//	public List<Vector3> positions;
	// Use this for initialization
	void Start () {
		startTime = Time.time;
//		for
//		positions.Add (new Vector3 (Random.value * 2, Random.value * 2, Random.value * 2));

	}
	
	// Update is called once per frame
	void Update () {
		if (endPosition.x == 0 && endPosition.y == 0) {
			endPosition = new Vector3 (Random.value * 4-2, Random.value * 2-1, Random.value * 4-2);
			journeyLength = Vector3.Distance(startPosition,endPosition);
		}

		startPosition = transform.position;
		float distCovered = (Time.time - startTime) * 1f;
		float fracJourney = distCovered / journeyLength;
//		foreach (Transform child in transform) {
			
		Vector3 newPosition = Vector3.Lerp (endPosition*distCovered, startPosition, fracJourney);
			this.gameObject.transform.position = newPosition;
//		}
	}

}
