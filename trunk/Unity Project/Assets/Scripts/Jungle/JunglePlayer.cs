using UnityEngine;
using System.Collections;

public class JunglePlayer : MonoBehaviour {

    [SerializeField] private GUIText m_GoldNumberText;
    [SerializeField] private FPSInputController m_FPSController;

    private int m_NumberOfGold;
    private bool m_Posioned;

    [SerializeField] private float m_PosionLength;
    private float m_PosionTimer;

    public Vector3 SpawnLocation;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("Gold"))
        {
            DestroyObject(other.gameObject);
            SetGold(1);
            
        }
        if (other.gameObject.tag.Equals("Water"))
        {
            transform.position = SpawnLocation;
        }
    }

    private void SetGold(int amount)
    {
        m_NumberOfGold += amount;
        m_GoldNumberText.text = m_NumberOfGold + "";
    }

    public void Posion()
    {
        print("Posion");
        m_PosionTimer = 0;
        if (!m_Posioned)
        {            
            m_Posioned = true;
            m_FPSController.SendMessage("SwapInput");
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
        m_FPSController.SendMessage("SwapInput");
    }

}
