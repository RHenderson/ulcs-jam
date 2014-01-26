using UnityEngine;
using System.Collections;

public class SpaceGame : GoldGame {

    [SerializeField]
    private GUIText m_TimeText;

    [SerializeField]
    private float m_MaxTime = 30;
    private float m_Timer;

    private bool m_Dead;

    private void Update()
    {
        m_Timer += Time.deltaTime;
        m_TimeText.text = "Time: " + m_Timer;
        if (m_Timer > m_MaxTime && !m_Dead)
        {
            m_Dead = true;
            Die();
        }
    }

    private void Die()
    {
        m_InfoText.text = "Game Over";
        m_InfoText.enabled = true;
        if (FadeScript.Instance)
            FadeScript.Instance.Finish(FadeScript.LevelCode.LOSE, 0);
    }
}
