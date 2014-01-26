using UnityEngine;
using System.Collections;

public class RoomInputScript : MonoBehaviour
{
	
	[SerializeField]
	private Transform player;
	[SerializeField]
	private float shrinkRate = 5.0f;
	[SerializeField]
	private float minScale = 0.3f;
	[SerializeField]
	private Renderer indicator;

    [SerializeField]
    private GUIText m_InfoDisplay;
    [SerializeField]
    private GUIText m_ClickToInteractText;

    [SerializeField]
    private Vignetting m_Vignetting;

    void Start()
    {
        m_ClickToInteractText.enabled = false;
        m_InfoDisplay.enabled = false;
        m_Vignetting.intensity += FadeScript.Instance.totalWins();
    }
	
	// Update is called once per frame
	void Update ()
	{	
	
		Transform cam = Camera.main.transform;
		RaycastHit hit = new RaycastHit ();


        if (Physics.Raycast(cam.position, cam.forward, out hit, 10))
        {
            if (hit.transform.tag == "Memento" || hit.transform.tag == "Lid")
            {
                indicator.material.color = Color.green;
                m_ClickToInteractText.enabled = true;

                if (hit.transform.tag == "Memento")
                {
                    m_InfoDisplay.enabled = true;
                    m_InfoDisplay.text = hit.collider.gameObject.GetComponent<MementoScript>().description;
                }

            }
            else
            {
                indicator.material.color = Color.white;
                m_ClickToInteractText.enabled = false;
                m_InfoDisplay.enabled = false;
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (hit.transform.tag == "Lid")
                {
                    hit.collider.gameObject.GetComponent<ChestScript>().Open();
                }

                if (hit.transform.tag == "Memento")
                {
					MementoScript mem = hit.collider.gameObject.GetComponent<MementoScript>();
					if (FadeScript.Instance.LevelPlayed(mem.sceneToLoad)) {
                    	audio.Play();
                    	StartCoroutine(LevelTransistion(mem));
					}
                }
            }
        }
        else
        {
            indicator.material.color = Color.white;
            m_ClickToInteractText.enabled = false;
            m_InfoDisplay.enabled = false;
        }
	}
	
	IEnumerator LevelTransistion (MementoScript mem)
	{		
		while (player.localScale.x > minScale + 0.1f) {
			player.localScale = Vector3.Lerp (player.localScale, new Vector3 (minScale, minScale, minScale), shrinkRate * Time.deltaTime);
			yield return new WaitForEndOfFrame();
		}
		
		yield return new WaitForSeconds(2);
		
		FadeScript.Instance.FadeOut (mem.sceneToLoad);
	}
}
