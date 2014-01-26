using UnityEngine;
using System.Collections;

public class HackScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public void Finish (int i) {
		if (i == 1) {
			FadeScript.Instance.Finish(FadeScript.LevelCode.WIN, 0);
		} else {
			FadeScript.Instance.Finish(FadeScript.LevelCode.LOSE, 0);
		}
	}
}
