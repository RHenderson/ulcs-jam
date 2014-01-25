using UnityEngine;
using System.Collections;

/// <summary>
/// This script is attached to the camera game object and handles following
/// a target object from a 3rd person perspective
/// </summary>
public class ExampleThirdPersonCamera : MonoBehaviour
{
    /// <summary>
    /// The speed at which the camera will move towards the target
    /// </summary>
    [SerializeField] private float m_FollowSpeed;

    /// <summary>
    /// We need a position offset because we do not actually want
    /// the camera to move to the exact position of the target
    /// </summary>
    [SerializeField] private Vector3 m_PositionOffset;

    /// <summary>
    /// The look offset is used to make the camera look slightly in
    /// front of the target to create a better field of view
    /// </summary>
    [SerializeField] private Vector3 m_LookOffset;

    /// <summary>
    /// The transform that the camera should follow in the scene
    /// </summary>
    [SerializeField] private Transform m_Target;

    /// <summary>
    /// We cache a transform to save on performance.
    /// Accessing the transform directly is slightly inefficient
    /// </summary>
    private Transform m_CachedTransform;

    private void Awake()
    {
        //Save a reference to this transform
        m_CachedTransform = transform;
    }
	
	// Update is called once per frame
	void Update ()
	{
        /*
         * Here we are calculating the direction the camera should look
         * To get a direction vector you take away the target position from the current position
         * We then use a fuction Quaternion.LookRotation to give us the rotation to face from the direction
         */
        Vector3 lookDirection = (m_Target.position + m_Target.TransformDirection(m_LookOffset)) -
	                            m_CachedTransform.position;
        Quaternion lookRotation = Quaternion.LookRotation(lookDirection);

        /*
         * Here we rotate the current rotation over time to match the direction we want to look in
         * this prevents the camera snapping to the angle
         */
	    m_CachedTransform.rotation = Quaternion.Lerp(m_CachedTransform.rotation, lookRotation, Time.deltaTime*4);

        /*
         * We are now moving the camera's position towards the target with the offset in mind.
         * The function m_Target.TransformPoint converts the offset into a local position around the target
         */
        m_CachedTransform.position = Vector3.Slerp(m_CachedTransform.position, m_Target.TransformPoint(m_PositionOffset),
	                                               Time.deltaTime*m_FollowSpeed);
	}
}
