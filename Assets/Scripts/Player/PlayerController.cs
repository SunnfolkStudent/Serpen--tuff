using System.Collections;
using TMPro;
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
    private GameObject _lightNormal;
    private GameObject _lightHide;
    private InputSystem_Actions _inputSystem;
    private bool isInvincible = false;
    public bool canHide;
    public bool isDying;
    public CanvasGroup canvasGroupScreenFade;
    
    private BoxCollider2D _boxCollider2D;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;


    
    private void Start()
    {
        _input = GetComponent<InputManager>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _lightNormal = transform.GetChild(1).gameObject;
        _lightHide = transform.GetChild(2).gameObject;
        _rigidbody2D.gravityScale = 1.5f;
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _lightHide.SetActive(false);
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
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


		if (_input.Jump && !isInvincible && canHide && playerIsGrounded)
		{
			Debug.Log("Player turned invincible!");
			moveSpeed = 0f;
			_rigidbody2D.gravityScale = 0f;
			_boxCollider2D.enabled = false;
			isInvincible = true;
			_lightNormal.SetActive(false);
			_lightHide.SetActive(true);
		}
		else if (_input.Jump && isInvincible && canHide && playerIsGrounded)
		{
			moveSpeed = 2f;
			_rigidbody2D.gravityScale = 1.5f;
			_boxCollider2D.enabled = true;
			isInvincible = false;
			_lightNormal.SetActive(true);
			_lightHide.SetActive(false);
			Debug.Log("Player is no longer invincible!");	
		}


		/*if (_input.Jump && playerIsGrounded && canHide && !isInvincible)
		{
			StartCoroutine(BecomeTemporarilyInvincible());
		}*/

		
		
		if (_input.Horizontal < 0)
		{
			_lightNormal.transform.rotation = new Quaternion( 0f,  180f, 0, 0f);
			_lightHide.transform.localPosition = new Vector2(-0.5f, -0.2f);
			_lightNormal.transform.localPosition = new Vector2(-0.5f, -0.2f);
			_spriteRenderer.flipX = true;
		}
		else if (_input.Horizontal > 0)
		{
			_lightNormal.transform.rotation = new Quaternion( 0f,  0f, 0, 0f);
			_lightHide.transform.localPosition = new Vector2(0.5f, -0.2f);
			_lightNormal.transform.localPosition = new Vector2(0.5f, -0.2f);
			_spriteRenderer.flipX = false;
		}

		UpdateAnimations();
	}
	
	private void OnTriggerStay2D(Collider2D other)
	{
		if (other.transform.CompareTag("Hide"))
		{
			canHide = true;
		}
		if (other.transform.CompareTag("NoHide"))
		{
			canHide = false;
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.transform.CompareTag("Stage1Exit"))
		{
			StartCoroutine(FadeOutScreen());
			
		}

		if (other.transform.CompareTag("Stage2Exit"))
		{
			StartCoroutine(FadeOutScreenMire());
		}
		
	}

	private IEnumerator FadeOutScreen()
	{
		while (canvasGroupScreenFade.alpha  < 1)
		{
			canvasGroupScreenFade.alpha += 0.01f;
			yield return new WaitForSeconds(0.01f);
			yield return null;
		}
		SceneManager.LoadScene("Mire");
		yield return null;
        
	}

	private IEnumerator FadeOutScreenMire()
	{
		SceneManager.LoadScene("Village");
		yield return null;
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
	/*private IEnumerator BecomeTemporarilyInvincible()
	{
		Debug.Log("Player turned invincible!");
		moveSpeed = 0f;
		_rigidbody2D.gravityScale = 0f;
		_circleCollider2D.enabled = false;
		isInvincible = true;
		yield return new WaitForSeconds(5f);
		moveSpeed = 2f;
		_rigidbody2D.gravityScale = 1.5f;
		_circleCollider2D.enabled = true;
		isInvincible = false;
		Debug.Log("Player is no longer invincible!");	
	}*/
	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.transform.CompareTag("Death"))
		{
			StartCoroutine(PlayerDeath());
		}
	}

	private IEnumerator PlayerDeath()
	{
		isDying = true;
		_animator.Play("death_R");
		yield return new WaitForSeconds(0.5f);
		SceneManager.LoadScene("Main Menu");
	}

	private void UpdateAnimations()
	{
		if (playerIsGrounded && !isDying)
		{
			if (_input.Horizontal != 0)
			{
				_animator.Play("right");
			}
			else
			{
				_animator.Play("idle_R");
			}
		}
		
	}
	
}

