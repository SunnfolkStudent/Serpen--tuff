using UnityEngine;

public class PlayerController : MonoBehaviour
{ 
    public float moveSpeed = 5f;
    public float jumpSpeed = 7f;
    public bool playerIsGrounded;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public Vector2 groundBoxSize = new Vector2(0.8f, 0.2f);
    private InputManager _input;
    private Rigidbody2D _rigidbody2D;
    private GameObject _light;
    

    private void Start()
    {
        _input = GetComponent<InputManager>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _light = transform.GetChild(1).gameObject;
    }
	private void Update()
	{
		if (Physics2D.OverlapBox(groundCheck.position, groundBoxSize, 0f, whatIsGround))
		{
			playerIsGrounded = true;
		}
		else
		{
			playerIsGrounded = false;
		}

		if (_input.Jump && playerIsGrounded)
		{
			_rigidbody2D.linearVelocityY = jumpSpeed;
		}

		if (_input.Horizontal < 0)
		{
			_light.transform.rotation = new Quaternion( 0f,  180f,  0, 0f);
		}
		else if (_input.Horizontal > 0)
		{
			_light.transform.rotation = new Quaternion( 0f,  0f, 0, 0f);
		}
	}
	
    		
	private void FixedUpdate()
	{
		_rigidbody2D.linearVelocityX = _input.Horizontal * moveSpeed;
	}
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireCube(groundCheck.position, groundBoxSize);
	}
}
