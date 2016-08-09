using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class pickupParent : MonoBehaviour {
	SteamVR_TrackedObject obj;
	SteamVR_Controller.Device device;
	// Use this for initialization
	void Start () {
		obj = GetComponent<SteamVR_TrackedObject> ();
	}

	void FixedUpdate () {
		device = SteamVR_Controller.Input ((int)obj.index);
		if (device.GetTouch (SteamVR_Controller.ButtonMask.Trigger)) {
			Debug.Log ("Touching the trigger");
		}
	}

	void OnTriggerStay(Collider col){
		Debug.Log ("Colliding with " + col.name);
		if (device.GetTouch (SteamVR_Controller.ButtonMask.Trigger)) {
			//Debug.Log ("Touching the trigger");
			col.gameObject.transform.SetParent (this.gameObject.transform);
			col.attachedRigidbody.isKinematic = true;
		}

		if (device.GetTouchUp (SteamVR_Controller.ButtonMask.Trigger)) {
			//Debug.Log ("let go the trigger");
			Vector3 temp = col.gameObject.transform.position;
			col.gameObject.transform.SetParent (null);
			col.attachedRigidbody.isKinematic = false;
			col.gameObject.transform.position = temp;
		}

		if (device.GetTouchDown (SteamVR_Controller.ButtonMask.Grip)) {
			Debug.Log ("Explode!r");
		}
	}
}
