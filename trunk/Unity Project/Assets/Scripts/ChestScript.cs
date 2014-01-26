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
		
		if (clickedLid)
		{
			//makes the lid spin
			transform.Rotate(new Vector3 (90, 0, 0) * Time.deltaTime);
			
			if (transform.localEulerAngles.x > 350)
				clickedLid = false;
		}
	
	}
	
	public void Open ()
	{
		clickedLid = true;
	}
}
