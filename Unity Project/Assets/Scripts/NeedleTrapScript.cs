using UnityEngine;
using System.Collections;

public class NeedleTrapScript : MonoBehaviour
{
	
	[SerializeField] private Transform needle;
    [SerializeField] private Transform target;
	[SerializeField] private float rateOfFire = 1;
	[SerializeField] private bool firing = true;
	
	void Start ()
	{
		StartCoroutine (Fire ());
	}
	
	IEnumerator Fire ()
	{
        yield return new WaitForSeconds(Random.Range(0, 1));
		while (firing) {
			Transform needleTrans = Instantiate (needle) as Transform;
			needleTrans.position = transform.position;
            needleTrans.LookAt(target);
			yield return new WaitForSeconds(rateOfFire);
		}
	}
}
