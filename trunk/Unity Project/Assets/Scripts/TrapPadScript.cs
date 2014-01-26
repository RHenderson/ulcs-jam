using UnityEngine;
using System.Collections;

public class TrapPadScript : MonoBehaviour
{
	[SerializeField]
	private Vector3 boost;

	void OnTriggerEnter(Collider car) {
		Debug.Log(car.gameObject);
		car.attachedRigidbody.AddForce(car.transform.TransformDirection(Vector3.back * 500), ForceMode.VelocityChange);
	}
}



