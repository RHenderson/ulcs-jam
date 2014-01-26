using UnityEngine;
using System.Collections;

public class racegame : MonoBehaviour {

    [SerializeField]
    private GUIText m_TimeText;

    [SerializeField]
    private GUIText m_InfoText;

	[SerializeField] 
	private float maxTime = 240;
	private float timer;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {		
        m_TimeText.text = "Time: " + (int) timer;
		timer += Time.deltaTime;
		if(timer>=maxTime){
			Lose ();
		}
	}
	void Lose(){
		m_InfoText.text = "Game Over";
        m_InfoText.enabled = true;
        if (FadeScript.Instance)
            FadeScript.Instance.Finish(FadeScript.LevelCode.LOSE, 0);		
	}
	void Win(){
		m_InfoText.text = "You Win!";
		m_InfoText.enabled = true;
        if (FadeScript.Instance)
            FadeScript.Instance.Finish(FadeScript.LevelCode.WIN, 0);	
	}
	void OnTriggerEnter(Collider c){
		print(c.tag);
	if(c.tag.Equals("Finish")){
		Win ();
		}		
	}
}
