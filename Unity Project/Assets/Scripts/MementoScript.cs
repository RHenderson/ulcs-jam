using UnityEngine;
using System.Collections;

public class MementoScript : MonoBehaviour {
	
	public string sceneToLoad;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void MoveLevel() {
		Application.LoadLevel(1);
	}
}
