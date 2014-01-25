using UnityEngine;
using System.Collections;

public class RoomInputScript : MonoBehaviour
{
	
	[SerializeField]
	private Transform player;
	[SerializeField]
	private float shrinkRate = 5.0f;
	[SerializeField]
	private float minScale = 0.3f;
	[SerializeField]
	private Renderer fade;
	[SerializeField]
	private Color targetColour;
	
	// Use this for initialization
	void Start ()
	{
		if (!Application.isEditor) 
			Screen.lockCursor = true;
	}
	
	// Update is called once per frame
	void Update ()
	{	
		if (Input.GetMouseButtonDown (0)) {
	
			Transform cam = Camera.main.transform;
			RaycastHit hit = new RaycastHit ();
		
		
			if (Physics.Raycast (cam.position, cam.forward, out hit, 10)) {
				if (hit.transform.tag == "Lid") {
					hit.collider.gameObject.GetComponent<ChestScript> ().Open ();
				}
				
				if (hit.transform.tag == "Memento") {
					StartCoroutine (LevelTransistion (hit.collider.gameObject.GetComponent<MementoScript> ()));
				}
			}
		}
	}
	
	IEnumerator LevelTransistion (MementoScript mem)
	{		
		while (player.localScale.x > minScale + 0.1f) {
			player.localScale = Vector3.Lerp (player.localScale, new Vector3 (minScale, minScale, minScale), shrinkRate * Time.deltaTime);
			yield return new WaitForEndOfFrame();
		}
		
		yield return new WaitForSeconds(1);
		
		while (fade.material.color.a <= 0.99f) {
			fade.material.color = Color.Lerp(fade.material.color, targetColour, shrinkRate * Time.deltaTime);
			yield return new WaitForEndOfFrame();
		}
		
		yield return new WaitForSeconds(2);
		
		mem.MoveLevel ();
	}
}
