using UnityEngine;
using System.Collections;

/// <summary>
/// The player controller implements player specific functionality
/// </summary>
public class ExamplePlayerController : ExampleCombatant
{
	
	protected override void Update ()
	{
        base.Update();
        HandleMove(Input.GetAxis("Vertical"));

        /*
         * We are checking if being held down and if it is
         * we initiate the attacking animation and co-routine
         * Fire1 is set up in the Input manager in the editor (usually left mouse button)
         */
        if (Input.GetButton("Fire1"))
        {
            if(!m_Attacking)
            {
                StartCoroutine(HandleAttack());
                m_Animator.SetBool("Attack", true);
            }
        }

        //If the button has been released stop playing the animation
        if (Input.GetButtonUp("Fire1"))
        {
            m_Animator.SetBool("Attack", false);
        }
	}

    protected override void HandleVerticalMotion()
    {
        if (Input.GetButtonDown("Jump"))
        {
            StartCoroutine(Jump());
        }
        base.HandleVerticalMotion();
    }

    /// <summary>
    /// Late update is called after all other updates
    /// we rotate the player here to prevent glitches when moving
    /// </summary>
    private void LateUpdate()
    {
        m_CachedTransform.Rotate(0, Input.GetAxis("Horizontal") * m_RotateSpeed * Time.deltaTime, 0);
    }
}
