using UnityEngine;

public class NøkkenEnemy : MonoBehaviour
{
    private Transform _target;
    private Rigidbody2D _rigidbody;
    private int _direction;
    

    public float moveSpeed;
    
   
    private void Start()
    {
        _target = GameObject.Find("Player").transform;
        _rigidbody = GetComponent<Rigidbody2D>();
       

        if (_target.transform.position.x > transform.position.x)
        {
            _direction = 1;
        }
        else if (_target.transform.position.x < transform.position.x)
        {
            _direction = -1;
        }
    }

    private void FixedUpdate()
    {
        _rigidbody.linearVelocityX = moveSpeed * _direction;
    }
   
   
}
