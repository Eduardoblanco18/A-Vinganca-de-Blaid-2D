using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5;

    private void Start()
    {
        GameManager.Instance.inputManager.OnJump += HandleJump;
    }

    private void Update()
    {
        float moveDirection = GameManager.Instance.inputManager.Movement;
        transform.Translate(moveDirection * Time.deltaTime * moveSpeed, 0, 0);
    }

    private void HandleJump()
    {
        Debug.Log("Estou pulando!");
    }
}
