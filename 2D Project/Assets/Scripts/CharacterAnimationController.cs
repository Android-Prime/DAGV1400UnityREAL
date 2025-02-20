using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        HandleAnimations();
    }

    private void HandleAnimations()
    {
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
        }
    }

}
