using UnityEngine;
using System.Collections;

public class ChestScript : MonoBehaviour
{
	
	private bool clickedLid;
	private bool alreadyClicked;
	private Vector3 rotVec;

	// Use this for initialization
	void Start ()
	{
		rotVec = new Vector3 (90, 0, 0);
	}
	
	public void Open() {
		StartCoroutine(open());
	}
	
	private IEnumerator open() {
		while (transform.localEulerAngles.x < 350) {
			Debug.Log("In");
			transform.Rotate(rotVec * Time.deltaTime);
			yield return new WaitForEndOfFrame();
		}
		
	}
}
