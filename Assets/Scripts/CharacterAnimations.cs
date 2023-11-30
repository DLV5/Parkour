using UnityEngine;

public class CharacterAnimations : MonoBehaviour
{
    [Tooltip("Put animator from model here")]
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
       
    }

    public void SetSpeed(float speed)
    {
        animator.SetFloat("Speed", speed);
    }

    public void SetIsGrounded(bool isGrounded)
    {
        animator.SetBool("IsGrounded", isGrounded);
    }

    public void SetIsJumping(bool isJumping)
    {
        animator.SetBool("IsJumping", isJumping);
    }

    public void SetIsFalling(bool isFalling)
    {
        animator.SetBool("IsFalling", isFalling);
    }
}
