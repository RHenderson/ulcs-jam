using UnityEngine;
using System.Collections;

public class TriggerPoint : MonoBehaviour {

    [SerializeField] private InteractiveObject[] m_InteractiveObjects;

    void OnTriggerEnter(Collider other)
    {
        foreach (InteractiveObject io in m_InteractiveObjects)
        {
            io.Interact();
        }
    }
}
