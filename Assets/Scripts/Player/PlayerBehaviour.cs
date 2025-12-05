using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private float jumpForce = 3;

    private Rigidbody2D playerRigidbody;
    private IsGroundedChecker isGrounded;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        isGrounded = GetComponent<IsGroundedChecker>();
    }

    private void Start()
    {
        GameManager.Instance.inputManager.OnJump += HandleJump;
    }

    private void Update()
    {
        float moveDirection = GameManager.Instance.inputManager.Movement;
        transform.Translate(moveDirection * Time.deltaTime * moveSpeed, 0, 0);

        if (moveDirection < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (moveDirection > 0)
        {
            transform.localScale = Vector3.one;
        }
    }

    private void HandleJump()
    {
        if (isGrounded.IsGrounded() == false) return;
        playerRigidbody.linearVelocity += Vector2.up * jumpForce;
    }
}
