using UnityEngine;
using System.Collections;

public class MementoScript : MonoBehaviour {
	
	[SerializeField] private int sceneToLoad;
	
	public void MoveLevel() {
		Application.LoadLevel(sceneToLoad);
	}
}
