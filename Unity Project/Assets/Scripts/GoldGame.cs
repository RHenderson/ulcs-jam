using UnityEngine;
using System.Collections;

public class GoldGame : MonoBehaviour {

    [SerializeField]
    protected GUIText m_GoldNumberText;
    
    [SerializeField]
    protected AudioSource m_PickupSound;

    [SerializeField]
    protected GUIText m_InfoText;

    [SerializeField]
    protected int m_GoldToCollect = 5;
    public int NumberOfGold { get { return m_NumberOfGold; } }
    protected int m_NumberOfGold;

	// Use this for initialization
	protected virtual void Start () {
        m_GoldNumberText.text = "Gold: " + 0 + "/" + m_GoldToCollect;
	}

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("Gold"))
        {
            m_PickupSound.Play();
            DestroyObject(other.gameObject);
            SetGold(1);

        }
    }

    protected void SetGold(int amount)
    {
        m_NumberOfGold += amount;
        m_GoldNumberText.text = "Gold: " + m_NumberOfGold + "/" + m_GoldToCollect;
    }

}
