using UnityEngine;
using System.Collections;

public class ChestScript : MonoBehaviour
{
	
	private bool clickedLid;

	// Use this for initialization
	void Start ()
	{
		clickedLid = false;
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	
	public void Open ()
	{
		if (!clickedLid) {
			transform.Rotate (new Vector3 (90, 0, 0));
			clickedLid = true;
		}
	}
}
