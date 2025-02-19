﻿using UnityEngine;
using System.Collections;

public class JunglePlayer : GoldGame {

    [SerializeField] private GUIText m_LifeText;
    [SerializeField] private FPSInputController m_FPSController;
    

    private bool m_Posioned;

    [SerializeField] private float m_PosionLength;
    private float m_PosionTimer;

    public Vector3 SpawnLocation;

    [SerializeField]
    private SepiaToneEffect m_ToneEffect;

    private int m_NumberOfLives = 3;

	// Use this for initialization
	protected override void Start () {
        base.Start();
        SpawnLocation = transform.position;
	}

    public bool HasEnoughGold()
    {
        bool gotGold = m_NumberOfGold >= m_GoldToCollect;
        if (!gotGold)
        {
            StartCoroutine(NotEnoughGold());
        }
        return gotGold;
    }

    private IEnumerator NotEnoughGold()
    {
        m_InfoText.text = "You Need More Gold To Open The Door, \n (You Must Construct Additional Pylons)";
        m_InfoText.enabled = true;
        yield return new WaitForSeconds(3);
        m_InfoText.enabled = false;
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if (other.gameObject.tag.Equals("Water"))
        {
            print(SpawnLocation);
            if (TakeLife())
            {
                transform.position = SpawnLocation;  
            }
                      
        }
    }

    

    private bool TakeLife()
    {
        m_NumberOfLives--;
        m_LifeText.text = "Lives: " + m_NumberOfLives;
        if (m_NumberOfLives <= 0)
        {            
            StartCoroutine(Die());
            return false;
        }
        return true;
    }

    private IEnumerator Die()
    {
        m_InfoText.text = "Game Over";
        m_InfoText.enabled = true;
        m_LifeText.enabled = false;
        m_FPSController.enabled = false;
        if(FadeScript.Instance)
            FadeScript.Instance.Finish(FadeScript.LevelCode.LOSE, 0);
        yield return new WaitForSeconds(5);
    }

    public void Posion()
    {
        print("Posion");
        m_PosionTimer = 0;
        if (!m_Posioned)
        {            
            m_Posioned = true;
            m_FPSController.SendMessage("SwapInput");
            m_ToneEffect.enabled = true;
            StartCoroutine(PosionCooldown());
        }        
    }

    private IEnumerator PosionCooldown()
    {
        while (m_PosionTimer < m_PosionLength)
        {
            m_PosionTimer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        m_PosionTimer = 0;
        m_Posioned = false;
        m_ToneEffect.enabled = false;
        m_FPSController.SendMessage("SwapInput");
    }

}
