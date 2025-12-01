using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private InputManager inputManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputManager = new InputManager();
    }

    private void Update()
    {
        float moveDirection = inputManager.Movement;
        transform.Translate(moveDirection, 0, 0);
    }
}
