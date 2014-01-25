using UnityEngine;
using System.Collections;

public class JungleDoor : InteractiveObject {
    
    [SerializeField] private Vector3 m_TargetRotation;
    [SerializeField] private float m_OpenSpeed = 10;

    public override void Interact()
    {
        StopAllCoroutines();
        StartCoroutine(Open());
    }

    private IEnumerator Open()
    {
        print("open");
        while (Vector3.Distance(m_TargetRotation, transform.localEulerAngles) > 0.5f)
        {
            transform.localEulerAngles = Vector3.Slerp(transform.localEulerAngles, m_TargetRotation, Time.deltaTime * m_OpenSpeed);
            yield return new WaitForEndOfFrame();
        }
        transform.localEulerAngles = m_TargetRotation;
    }
}
