using UnityEngine;
using System.Collections;

public class FadeScript : MonoBehaviour
{
	public static FadeScript Instance {get{return instance;}}
	private static FadeScript instance;
	
	[SerializeField]
	private Renderer fade;
	[SerializeField]
	private float speed = 5.0f;
	private Color opaque = new Color (0, 0, 0, 1);
	private Color transparent = new Color (0, 0, 0, 0);
	
	void Awake()
	{
		instance = this;
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
