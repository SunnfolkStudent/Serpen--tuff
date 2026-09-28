using UnityEngine;

public class NisseEnemy : MonoBehaviour
{
    public float moveSpeed;

    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rigidbody2D.linearVelocityX= moveSpeed;
    }
    
}
