using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Animator animator;
    private IsGroundedChecker isGrounded;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        isGrounded = GetComponent<IsGroundedChecker>();
    }

    private void Update()
    {
        bool isMoving = GameManager.Instance.inputManager.Movement != 0;
        animator.SetBool("isMoving", isMoving);

        bool Grounded = isGrounded.IsGrounded();
        animator.SetBool("Grounded", Grounded);
    }
}
