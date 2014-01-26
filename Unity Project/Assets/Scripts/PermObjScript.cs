using UnityEngine;
using System.Collections;

public class PermObjScript : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad(gameObject);
	}
}
