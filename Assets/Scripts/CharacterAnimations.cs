using Photon.Pun;
using UnityEngine;

public class CharacterAnimations : MonoBehaviour
{
    [Tooltip("Put animator from model here")]
    public Animator animator;

    public GameObject model;

    private PhotonView _photonView;

    private void Start()
    {
        _photonView = GetComponent<PhotonView>();

        if (_photonView.IsMine)
        {
            model.layer = LayerMask.NameToLayer("MyCharacter");
        }
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
    public void SetIsDead(bool isDead)
    {
        animator.SetBool("IsDead", isDead);
    }
}
