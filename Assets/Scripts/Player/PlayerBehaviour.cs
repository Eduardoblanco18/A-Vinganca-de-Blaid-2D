using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    private InputManager inputManager;
    [SerializeField] private float moveSpeed = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputManager = new InputManager();
    }

    private void Update()
    {
        float moveDirection = inputManager.Movement * Time.deltaTime * moveSpeed;
        transform.Translate(moveDirection, 0, 0);
    }
}
