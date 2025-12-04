using UnityEngine;

public class IsGroundedChecker : MonoBehaviour
{
    [SerializeField] private Transform checkerPosition;
    [SerializeField] private Vector2 checkerSize;
    [SerializeField] private LayerMask groundLayer;

    public bool IsGrounded()
    {
        return Physics2D.OverlapBox(checkerPosition.position, checkerSize, 0f, groundLayer);
    }

    private void OnDrawGizmos()
    {
        if (checkerPosition == null) return;
        if (IsGrounded())
        {
            Gizmos.color = Color.red;
        }
        else
        {
            Gizmos.color = Color.green;
        }
            Gizmos.DrawWireCube(checkerPosition.position, checkerSize);
    }
}
