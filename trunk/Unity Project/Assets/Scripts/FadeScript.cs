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
        if (FadeScript.Instance != null && !FadeScript.Instance.Equals(this))
            DestroyImmediate(transform.parent.gameObject);            
        else
            instance = this;
		
		
		if (!Application.isEditor) 
			Screen.lockCursor = true;
	}
	
	void Start ()
	{
        levelProgress = new LevelCode[4];
		fade.material.color = opaque;
		FadeIn();
	}
	
	void OnLevelWasLoaded (int level)
	{
			fade.material.color = opaque;
			FadeIn();
		
		if (level == 0) {
            if (FadeScript.Instance != null && !FadeScript.Instance.Equals(this))
                DestroyImmediate(transform.parent.gameObject);    
            
			float vignette = 8 - totalWins();
            Camera.main.gameObject.SendMessage("ChangeIntensity", vignette);
            Debug.Log("Vignette " + vignette + " " + (Camera.main.GetComponent<Vignetting>() != null));
		}
	}
	
	public int totalWins() {
		int total = 0;
		
		foreach (LevelCode l in levelProgress) {
			total += (int) l;
		}
        print(total);
		return total;
	}
	
	public void Finish(LevelCode success, int toLoad) {
		levelProgress[Application.loadedLevel - 1] = success;
		FadeOut(toLoad);
		
	}
	
	public void FadeIn ()
	{
		StartCoroutine (FadeInTransition ());
	}
	
	public void FadeOut (int toLoad)
	{
		StartCoroutine (FadeOutTransition (toLoad));
	}
	
	//opaque to transparent
	IEnumerator FadeOutTransition (int toLoad)
	{
		while (fade.material.color.a <= 0.99f) {
			fade.material.color = Color.Lerp (fade.material.color, opaque, speed * Time.deltaTime);
			yield return new WaitForEndOfFrame();
		}
		
		fade.material.color = opaque;
		Application.LoadLevel(toLoad);
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
