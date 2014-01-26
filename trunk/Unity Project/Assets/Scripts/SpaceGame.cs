using UnityEngine;
using System.Collections;

public class SpaceGame : GoldGame {

    [SerializeField]
    private GUIText m_TimeText;

    [SerializeField]
    private float m_MaxTime = 120;
    private float m_Timer;

    private bool m_Dead;
	
	private void Start()
	{
		m_Timer = m_MaxTime;
	}

    private void Update()
    {
        m_Timer -= Time.deltaTime;
        m_TimeText.text = "Time: " + (int)m_Timer;
        if (m_Timer < 0 && !m_Dead)
        {
			Die();
            m_Dead = true;
        }
    if(m_NumberOfGold >= m_GoldToCollect && !m_Dead) {
				Win();
			m_Dead = true; 
			}
	}

    private void Die()
    {
        m_InfoText.text = "Game Over";
        m_InfoText.enabled = true;
        if (FadeScript.Instance)
            FadeScript.Instance.Finish(FadeScript.LevelCode.LOSE, 0);
    }

	private void Win()
	{
		m_InfoText.text = "You Win!";
		m_InfoText.enabled = true;
        if (FadeScript.Instance)
            FadeScript.Instance.Finish(FadeScript.LevelCode.WIN, 0);
    }
}