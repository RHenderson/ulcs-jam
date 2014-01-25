using UnityEngine;

public class MovingPlatformScript : MonoBehaviour
{
	
	[SerializeField]
	private Vector3 moveTo;
	[SerializeField]
	private float speed;
	[SerializeField]
	private bool loop;
	private bool back;
	private Vector3 a;
	
	
	
	// Use this for initialization
	void Start ()
	{
		a = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (back) {
			
			if (transform.position != a) {
				transform.position = Vector3.MoveTowards (transform.position, a, speed * Time.deltaTime);
			} else {
				back = false;
			}
			
		} else {
		
			if (transform.position != moveTo) {
				transform.position = Vector3.MoveTowards (transform.position, moveTo, speed * Time.deltaTime);
			} else {
				back = true;
			}
		}
			
	}
}
