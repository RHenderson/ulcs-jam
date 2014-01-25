using UnityEngine;
using System.Collections;

public class NeedleTrapScript : MonoBehaviour
{
	
	[SerializeField]
	private Transform needle;
	[SerializeField]
	private float rateOfFire = 1;
	[SerializeField]
	private bool firing = true;
	
	void Start ()
	{
		StartCoroutine (Fire ());
	}
	
	IEnumerator Fire ()
	{
		while (firing) {
			Transform needleTrans = Instantiate (needle) as Transform;
			needleTrans.position = transform.position;
			yield return new WaitForSeconds(rateOfFire);
		}
	}
}
