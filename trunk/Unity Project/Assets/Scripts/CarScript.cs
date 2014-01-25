using UnityEngine;
using System.Collections;

public class CarScript : MonoBehaviour {
	
	private float speed = 20.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float spd = speed * Time.deltaTime;
		
		if (Input.GetKeyDown(KeyCode.W)) {
			Debug.Log("Hello");
			transform.Translate(new Vector3(0, 0, speed) * Time.deltaTime);
		}
	
	}
}
