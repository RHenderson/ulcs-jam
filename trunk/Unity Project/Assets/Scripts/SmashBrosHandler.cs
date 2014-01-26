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
	[SerializeField] GUIText objectiveText;
	[SerializeField] ParticleSystem sparks;
	[SerializeField] private AudioSource nearlyUp;
	[SerializeField] private AudioSource music;
	
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
		
		
		if ((maxTime-currentTime)<24 && (maxTime-currentTime)>23.9)
			nearlyUp.audio.Play();
		
		if  (score>=targetScore || (maxTime-currentTime)>=20){
			music.audio.pitch = 1.0f;
		} else if ((maxTime-currentTime)<20 && (maxTime-currentTime)>10){
			music.audio.pitch = 1.5f;
		} else if ((maxTime-currentTime)<=10 && (maxTime-currentTime)>5){
			music.audio.pitch = 1.75f;
		} else /*((maxTime-currentTime)<=5 )*/{
			music.audio.pitch = 2.0f;
		}
		
		if (currentTime >= maxTime){
			if (score >= targetScore){	
				if (FadeScript.Instance)
					FadeScript.Instance.Finish (FadeScript.LevelCode.WIN, 0);
			}else{
				if (FadeScript.Instance)
					FadeScript.Instance.Finish (FadeScript.LevelCode.LOSE, 0);
			}
		}
		
		if (currentTime > 4)
			objectiveText.enabled=false;
		
	}
	
	public void updateScore(int amount){
		if (canScore()){
		score += amount;
		scoreText.text = "Score: " + score.ToString();
			if ((score>=targetScore) && (score%100 == 0)){
				successClip.audio.Play();
				Debug.Log(score);
				sparks.Play();
			} else if (score % 400 == 0){
			clip.audio.Play();
			}
		}
	}
	
	public bool canScore()
	{
		return currentTime > 2;
	}
}
