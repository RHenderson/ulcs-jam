using UnityEngine;
using System.Collections;

public class FusRoDahScript : MonoBehaviour
{
	[SerializeField]
	private float force = 10;
	[SerializeField]
	private float distance = 10;
	[SerializeField]
	private AudioSource clip;
	
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonDown (0)) {
	
			RaycastHit hit = new RaycastHit ();
		
			if (Physics.Raycast (transform.position + new Vector3 (0, 1, 0), transform.forward, out hit,distance)) {
				if (hit.transform.tag.Equals ("a")) {
					//if (hit.rigidbody == null) {
						Rigidbody r = hit.collider.gameObject.rigidbody;
					//AddComponent<Rigidbody> ();
						//r.mass = 0.1f;
						r.AddExplosionForce (force, transform.position, 0);
						clip.audio.Play();
					//}
				}
			}
		}
	}
}
