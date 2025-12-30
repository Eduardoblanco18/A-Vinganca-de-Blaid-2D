using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    [SerializeField] private bool Blood;

    private Animator animator;
    private IsGroundedChecker isGrounded;
    private Health playerHealth;
    private int NumberAttacks = 0;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        isGrounded = GetComponent<IsGroundedChecker>();

        playerHealth = GetComponent<Health>();
        playerHealth.OnHurt += PlayHurtAnim;
        playerHealth.OnDead += PlayDeadAnim;

        GameManager.Instance.inputManager.OnAttack += PlayAttackAnim;
    }

    private void Update()
    {
        bool isMoving = GameManager.Instance.inputManager.Movement != 0;
        animator.SetBool("isMoving", isMoving);

        bool Grounded = isGrounded.IsGrounded();
        animator.SetBool("Grounded", Grounded);
    }

    private void PlayHurtAnim()
    {
        animator.SetTrigger("Hurt");
    }

    private void PlayDeadAnim()
    {
        animator.SetTrigger("Death");
        animator.SetBool("noBlood", Blood);
    }

    private void PlayAttackAnim()
    {
        if (NumberAttacks == 0)
        {
            animator.SetTrigger("Attack1");
            NumberAttacks++;
        } else if(NumberAttacks == 1)
        {
            animator.SetTrigger("Attack2");
            NumberAttacks++;
        } else
        {
            animator.SetTrigger("Attack3");
            NumberAttacks = 0;
        }
        
    }
}
