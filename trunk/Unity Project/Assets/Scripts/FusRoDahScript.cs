using UnityEngine;
using System.Collections;

public class FusRoDahScript : MonoBehaviour
{
	[SerializeField]
	private float force = 10;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		if (Input.GetMouseButtonDown (0)) {
	
			Transform cam = Camera.main.transform;
			RaycastHit hit = new RaycastHit ();
		
			if (Physics.Raycast (cam.position, cam.forward, out hit, 10)) {
				if (hit.transform.tag == "Squirrel") {
					if (hit.rigidbody == null) {
						Rigidbody r = hit.collider.gameObject.AddComponent<Rigidbody> ();
						r.mass = 0.1f;
						r.AddExplosionForce (force, transform.position, 0);
					}
				}
			}
		}
	}
}
