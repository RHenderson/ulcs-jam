using UnityEngine;
using System.Collections;

public class SmashBrosHandler : MonoBehaviour {
	
	private float currentTime = 0;
	[SerializeField] private float maxTime = 30;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	currentTime += Time.deltaTime;
		if (currentTime > maxTime){
		}
		
	}
}
