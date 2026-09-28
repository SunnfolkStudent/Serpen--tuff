using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private InputSystem_Actions _inputSystem;
    private bool isInvincible = false;
    public bool canHide;
    
    
    private CircleCollider2D _circleCollider2D;

    private void Start()
    {
        _input = GetComponent<InputManager>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _light = transform.GetChild(1).gameObject;
        _rigidbody2D.gravityScale = 0;
        _circleCollider2D = GetComponent<CircleCollider2D>();
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

		if (_input.Jump && playerIsGrounded && !canHide)
		{
			_rigidbody2D.linearVelocityY = jumpSpeed;
		}

		if (_input.Jump && playerIsGrounded && canHide)
		{
			if (isInvincible) return;
			StartCoroutine(BecomeTemporarilyInvincible());
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
	
	private void OnTriggerStay2D(Collider2D other)
	{
		if (other.transform.CompareTag("Hide"))
		{
			canHide = true;
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
	private IEnumerator BecomeTemporarilyInvincible()
	{
		Debug.Log("Player turned invincible!");
		_rigidbody2D.gravityScale = 0;
		_circleCollider2D.enabled = false;
		isInvincible = true;
		yield return new WaitForSeconds(5f);
		_rigidbody2D.gravityScale = 1;
		_circleCollider2D.enabled = true;
		isInvincible = false;
		Debug.Log("Player is no longer invincible!");
	}
	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.transform.CompareTag("Death"))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
}

