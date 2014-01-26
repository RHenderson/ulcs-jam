using UnityEngine;
using System.Collections;

public class MementoScript : MonoBehaviour
{
	public int sceneToLoad;
	
	private Color startcolor;

    public string description;
	
	public void MoveLevel ()
	{
		Application.LoadLevel (sceneToLoad);
	}

	void OnMouseEnter ()
	{
		startcolor = renderer.material.color;
		renderer.material.color = Color.white;
	}

	void OnMouseExit ()
	{
		renderer.material.color = startcolor;
	}
}
