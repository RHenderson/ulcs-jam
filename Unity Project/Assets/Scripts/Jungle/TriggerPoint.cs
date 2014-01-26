using UnityEngine;
using System.Collections;

public class TriggerPoint : MonoBehaviour {

    [SerializeField] private InteractiveObject[] m_InteractiveObjects;
    [SerializeField] private JunglePlayer m_JunglePlayer;

    void OnTriggerEnter(Collider other)
    {
        if (m_JunglePlayer.HasEnoughGold())
        {
            foreach (InteractiveObject io in m_InteractiveObjects)
            {
                io.Interact();
            }
        }        
    }
}
