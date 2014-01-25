using UnityEngine;
using System.Collections;

public class RoomInputScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetMouseButtonDown(0)) {
	
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit = new RaycastHit();
		
		
			if (Physics.Raycast(ray, out hit)) {
				if (hit.transform.tag == "Lid") {
					hit.collider.gameObject.GetComponent<ChestScript>().Open();
					Debug.Log("Hit");
				}
			}
			
		}
	}
}
