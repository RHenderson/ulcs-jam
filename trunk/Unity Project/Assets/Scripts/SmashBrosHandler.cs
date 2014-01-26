using UnityEngine;
using System.Collections;

public class SmashBrosHandler : MonoBehaviour {
	
	public static SmashBrosHandler Instance {get{return instance;}}
	private static SmashBrosHandler instance;
	
	private float currentTime = 0;
	[SerializeField] private float maxTime = 50;
	private int score = 0;
	[SerializeField] GUIText scoreText;
	[SerializeField]
	private AudioSource clip;
	[SerializeField] GUIText timeText;
	[SerializeField] int targetScore = 20000;
	[SerializeField]
	private AudioSource successClip;
	[SerializeField] GUIText targetText;
	
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
		timeText.text = (maxTime - currentTime).ToString("f1");
		targetText.text = "Target: " + targetScore.ToString();
		
		if (currentTime >= maxTime){
			if (score >= targetScore){	
				if (FadeScript.Instance)
					FadeScript.Instance.Finish (FadeScript.LevelCode.WIN, 0);
			}else{
				if (FadeScript.Instance)
					FadeScript.Instance.Finish (FadeScript.LevelCode.LOSE, 0);
			}
		}
		
	}
	
	public void updateScore(int amount){
		if (currentTime > 2){
		score += amount;
		scoreText.text = "Score: " + score.ToString();
			if ((score>targetScore) && (score%100 == 0)){
				successClip.audio.Play();
				Debug.Log(score);
			} else if (score % 500 == 0){
			clip.audio.Play();
			}
		}
	}
}
