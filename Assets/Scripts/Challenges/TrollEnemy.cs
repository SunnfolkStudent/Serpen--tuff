using UnityEngine;

public class TrollEnemy : MonoBehaviour
{
    public float moveSpeed;

    public LayerMask whatIsWall;
    public Transform wallCheck;
    private Rigidbody2D _rigidbody2D;
    
  
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    private void FixedUpdate()
    {
        _rigidbody2D.linearVelocityX = moveSpeed;
    }

    private bool DetectWall()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.1f, whatIsWall);
    }
    
    void Update()
    {
        if (DetectWall())
        {
            moveSpeed *= -1;
            transform.localScale = new Vector2(transform.localScale.x * -1f, 2f);
        }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(wallCheck.position, 0.1f);
    }


}
