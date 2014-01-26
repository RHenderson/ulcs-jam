using UnityEngine;
using System.Collections;

public class FinalSceneScript : InteractiveObject {

    [SerializeField] private GameObject m_PlayerObject;
    [SerializeField]
    private GameObject m_CutSceneCamera;
    [SerializeField]
    private Transform m_SpaceShip;

    [SerializeField]
    private Transform m_LiftPoint;
    [SerializeField]
    private Transform m_LightSpeedPoint;

    public override void Interact()
    {
        m_PlayerObject.SetActive(false);
        m_CutSceneCamera.SetActive(true);
        StartCoroutine(Cutscene());
    }

    private IEnumerator Cutscene()
    {
        while(Vector3.Distance(m_SpaceShip.position, m_LiftPoint.position) > 5){
            m_SpaceShip.position = Vector3.Lerp(m_SpaceShip.position, m_LiftPoint.position, Time.deltaTime * 0.5f);
            m_CutSceneCamera.transform.LookAt(m_SpaceShip);
            m_CutSceneCamera.transform.position = Vector3.Slerp(m_CutSceneCamera.transform.position, new Vector3(m_CutSceneCamera.transform.position.x, m_LiftPoint.position.y, m_CutSceneCamera.transform.position.z), Time.deltaTime * 0.25f);
            yield return new WaitForEndOfFrame();
        }
        Quaternion lookRotation = Quaternion.LookRotation(m_LightSpeedPoint.position - m_SpaceShip.position);
        while (Quaternion.Angle(m_SpaceShip.rotation, lookRotation) > 2)
        {
            m_SpaceShip.rotation = Quaternion.Lerp(m_SpaceShip.rotation, lookRotation, Time.deltaTime);
            m_CutSceneCamera.transform.LookAt(m_SpaceShip);
            yield return new WaitForEndOfFrame();
        }

        while (Vector3.Distance(m_SpaceShip.position, m_LiftPoint.position) > 2)
        {
            m_SpaceShip.position = Vector3.Lerp(m_SpaceShip.position, m_LightSpeedPoint.position, Time.deltaTime * 4);
            m_CutSceneCamera.transform.LookAt(m_SpaceShip);
            yield return new WaitForEndOfFrame();
        }
    }
}
