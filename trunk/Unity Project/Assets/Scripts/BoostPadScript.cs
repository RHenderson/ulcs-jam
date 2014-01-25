using UnityEngine;
using System.Collections;

public class BoostPadScript : MonoBehaviour {
	
	[SerializeField]
	private Vector3 boost;
	
	void OnTriggerEnter(Collider car) {
		Debug.Log(car.gameObject);
		car.attachedRigidbody.AddForce(boost, ForceMode.VelocityChange);
	}
}
