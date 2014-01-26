using UnityEngine;
using System.Collections;

public class SmashBrosHandler : MonoBehaviour {
	
	public static SmashBrosHandler Instance {get{return instance;}}
	private static SmashBrosHandler instance;
	
	private float currentTime = 0;
	[SerializeField] private float maxTime = 30;
	private int score = 0;
	[SerializeField] GUIText scoreText;
	[SerializeField]
	private AudioSource clip;
	// Use this for initialization
	void Awake () {
		instance = this;
		GameObject[] aObjects = GameObject.FindGameObjectsWithTag("a");
		foreach(GameObject a in aObjects){
			a.AddComponent<toyObjects>();	
		}
	}
	
	// Update is called once per frame
	void Update () {
	currentTime += Time.deltaTime;
		if (currentTime > maxTime){
		}
		
	}
	
	public void updateScore(int amount){
		if (currentTime > 2){
		score += amount;
		scoreText.text = score.ToString();
			if (score % 100 == 0){
			clip.audio.Play();
			}
		}
	}
}
