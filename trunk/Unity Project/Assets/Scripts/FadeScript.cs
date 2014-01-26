using UnityEngine;
using System.Collections;

public class FadeScript : MonoBehaviour
{
	public static FadeScript Instance {get{return instance;}}
	private static FadeScript instance;
	
	public enum LevelCode {
		WIN = 1,
		LOSE = -1,
		NOT_PLAYED = 0
	}
	
	[SerializeField]
	private Renderer fade;
	[SerializeField]
	private float speed = 5.0f;
	private Color opaque = new Color (0, 0, 0, 1);
	private Color transparent = new Color (0, 0, 0, 0);
	private LevelCode[] levelProgress;
	
	void Awake()
	{
		instance = this;
		levelProgress = new LevelCode[4];
		
		if (!Application.isEditor) 
			Screen.lockCursor = true;
	}
	
	void Start ()
	{
			fade.material.color = opaque;
			FadeIn();
	}
	
	void OnLevelWasLoaded (int level)
	{
			fade.material.color = opaque;
			FadeIn();
	}
	
	public int totalWins() {
		int total = 0;
		
		foreach (LevelCode l in levelProgress) {
			total += (int) l;
		}
		
		return total;
	}
	
	public void Finish(int level, LevelCode success) {
		levelProgress[level] = success;
		FadeOut();
	}
	
	public void FadeIn ()
	{
		StartCoroutine (FadeInTransition ());
	}
	
	public void FadeOut ()
	{
		StartCoroutine (FadeOutTransition ());
	}
	
	//opaque to transparent
	IEnumerator FadeOutTransition ()
	{
		while (fade.material.color.a <= 0.99f) {
			fade.material.color = Color.Lerp (fade.material.color, opaque, speed * Time.deltaTime);
			yield return new WaitForEndOfFrame();
		}
		
		fade.material.color = opaque;
	}
	
	IEnumerator FadeInTransition ()
	{
		while (fade.material.color.a >= 0.01f) {
			fade.material.color = Color.Lerp (fade.material.color, transparent, speed * Time.deltaTime);
			yield return new WaitForEndOfFrame();
		}
		
		fade.material.color = transparent;
	}
}
