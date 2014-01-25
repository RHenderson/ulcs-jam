using UnityEngine;
using System.Collections;

public class JunglePlayer : MonoBehaviour {

    [SerializeField] private GUIText m_GoldNumberText;

    private int m_NumberOfGold;

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
    }

    private void SetGold(int amount)
    {
        m_NumberOfGold += amount;
        m_GoldNumberText.text = m_NumberOfGold + "";
    }

}
