using UnityEngine;
using System.Collections;

/// <summary>
/// Combatant is our base class for all characters in the game
/// It implements genric behaviour which is used by both the player character
/// and the AI character.
/// </summary>
 /*
 * Require component means that whatever object this script it attached to
 * a character controller will be added automatically.
 * This is useful for preventing null references
 */
[RequireComponent(typeof(CharacterController))]
public class ExampleCombatant : MonoBehaviour {

    /// <summary>
    /// A reference to the character controller which we know will be 
    /// attached to the object
    /// </summary>
    protected CharacterController m_CharacterController;

    /// <summary>
    /// A reference to the animator component of the character which
    /// handles changing animation states
    /// </summary>
    [SerializeField] protected Animator m_Animator;

    [SerializeField] protected float m_MoveSpeed = 2;
    [SerializeField] protected float m_RotateSpeed = 10;
    [SerializeField] protected float m_JumpHeight = 20;
    [SerializeField] protected float m_AttackRange = 10;
    [SerializeField] protected float m_AttackRate = 0.5f;

    protected float m_Health = 3;

    protected bool m_Dead = false;

    protected Transform m_CachedTransform;
    protected Vector3 m_MoveDirection;
    protected Vector3 m_UpwardsMotion;

    protected bool m_Jumping;
    protected bool m_Attacking;

    protected virtual void Awake()
    {
        /*
         * Get component attempts to find the given component on the 
         * current game object
         */
        m_CharacterController = GetComponent<CharacterController>();
        m_CachedTransform = transform;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        //If we are dead then don't update
        if (m_Dead)
            return;
        HandleVerticalMotion();
    }

    /// <summary>
    /// Handle attack is a co-routine which behaves like an update function except you have more
    /// control over execution.
    /// We implement the behaviour for when a character attempts an attack
    /// </summary>
    /// <returns></returns>
    protected virtual IEnumerator HandleAttack()
    {
        //Set the flag to true to prevent further attack co-routines starting
        m_Attacking = true;

        /*
         * We create a ray from the current position into the direction we are facing
         * a ray is a 1 dimentional beam which can hit colliders
         */
        Ray ray = new Ray(m_CachedTransform.position + new Vector3(0, 1.5f, 0), m_CachedTransform.forward);
        
        //A raycast hit gives us information about what the ray above has hit
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, m_AttackRange))
        {
            ExampleCombatant combatant = hit.collider.GetComponent<ExampleCombatant>();
            if(combatant)
            {
                combatant.TakeDamage();
            }
        }
        yield return new WaitForSeconds(m_AttackRate);
        m_Attacking = false;
    }

    /// <summary>
    /// Here we handle what happens when this character is attacked
    /// </summary>
    public virtual void TakeDamage()
    {
        m_Health -= 1;
        if(m_Health <= 0)
        {
            Die();
        }
    }

    /// <summary>
    /// Called when the character should die and perform the death
    /// animation
    /// </summary>
    protected virtual void Die()
    {
        m_Animator.SetBool("Dead", true);
        m_Dead = true;
    }

    /// <summary>
    /// Moves the character forwards by a given speed and plays the run animation
    /// </summary>
    protected virtual void HandleMove(float forwardSpeed)
    {
        if (m_CharacterController.isGrounded)
        {
            m_MoveDirection = Vector3.zero;
            m_MoveDirection.z = forwardSpeed;
            m_MoveDirection = m_CachedTransform.TransformDirection(m_MoveDirection);
            m_MoveDirection *= m_MoveSpeed;
        }

        m_Animator.SetFloat("Speed", forwardSpeed);
        m_CharacterController.Move((m_MoveDirection + m_UpwardsMotion) * Time.deltaTime);
    }

    /// <summary>
    /// We handle any movement in the y axis here such as gravity
    /// </summary>
    protected virtual void HandleVerticalMotion()
    {
        if (!m_Jumping)
        {
            m_UpwardsMotion.y = Physics.gravity.y;
        }
    }

    /// <summary>
    /// This co-routine is called to execute a jump
    /// It plays the jump animation and then waits for the character to reach the jump apex
    /// It then slowly changes the y motion back to gravity to give a smoother transtion
    /// </summary>
    /// <returns></returns>
    protected virtual IEnumerator Jump()
    {
        m_Jumping = true;
        m_Animator.SetBool("Jump", m_Jumping);
        Vector3 originalPosition = m_CachedTransform.position;
        m_UpwardsMotion.y = -Physics.gravity.y;
        while (m_CachedTransform.position.y < originalPosition.y + m_JumpHeight)
        {
            yield return new WaitForEndOfFrame();
        }
        while (m_CachedTransform.position.y > originalPosition.y + 1)
        {
            m_UpwardsMotion.y = Mathf.Lerp(m_UpwardsMotion.y, Physics.gravity.y, Time.deltaTime * -Physics.gravity.y);
            yield return new WaitForEndOfFrame();
        }
        m_Jumping = false;
        m_Animator.SetBool("Jump", m_Jumping);
    }
}
