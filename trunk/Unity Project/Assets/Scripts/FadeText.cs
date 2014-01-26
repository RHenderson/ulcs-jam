using UnityEngine;
using System.Collections;

public class FadeText : MonoBehaviour {

    [SerializeField]
    private float m_FadeRate = 2;

    [SerializeField]
    private float m_WaitTime = 4;

    [SerializeField]
    private GUIText m_Text;

	// Use this for initialization
	void Start () {
        StartCoroutine(Fade());
	}

    private IEnumerator Fade()
    {
        yield return new WaitForSeconds(m_WaitTime);
        while (m_Text.color.a >= 0.1f)
        {
            Color c = m_Text.color;
            c.a = Mathf.Lerp(m_Text.color.a, 0, Time.deltaTime * m_FadeRate);
            m_Text.color = c;
            yield return new WaitForEndOfFrame();
        }
        m_Text.color = new Color(0, 0, 0, 0);
        m_Text.enabled = false;
    }
}
