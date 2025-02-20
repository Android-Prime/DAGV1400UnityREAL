using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        HandleAnimations();
    }

    private void HandleAnimations()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            animator.SetTrigger("RunTrigger");
        }
        else
        {
            animator.SetTrigger("IdleTrigger");
        }

        if (Input.GetButtonDown("Jump"))
        {
            animator.SetTrigger("JumpTrigger");
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetTrigger( "WallJumpTrigger");
/*           
        }    
        if (Input.GetButtonDown("Jump"))
        {
            animator.SetTrigger("DoubleJumpTrigger");
        }
        else
        {
            animator.SetTrigger("IdleTrigger");
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            animator.SetTrigger("HitTrigger");
        }
        else
        {
            animator.SetTrigger("IdleTrigger");
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetTrigger("FallTrigger");
        }
        else
        {
            animator.SetTrigger("IdleTrigger");
*/
            
        }
    }

}
