using System;
using System.Collections;
using UnityEngine;

public class NøkkenEnemy : MonoBehaviour
{
    private Transform _target;
    private Rigidbody2D _rigidbody;
    private int _direction;
    public GameObject Nøkken;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private bool NøkkenIsSpawning;

    public float moveSpeed;
    
   
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        
        _target = GameObject.Find("Player").transform;
        _rigidbody = GetComponent<Rigidbody2D>();
        
       

        if (_target.transform.position.x > transform.position.x)
        {
            _direction = 1;
            _spriteRenderer.flipX = true;
        }
        else if (_target.transform.position.x < transform.position.x)
        {
            _direction = -1;
            _spriteRenderer.flipX = false;
        }
    }

    private void FixedUpdate()
    {
        _rigidbody.linearVelocityX = moveSpeed * _direction;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("NøkkenKill"))
            Destroy(Nøkken);
    }

    public IEnumerator NøkkenSpawning()
    {
        NøkkenIsSpawning = true;
        _animator.Play("nøkken_Spawn");
        yield return new WaitForSeconds(2f);
        NøkkenIsSpawning = false;
    }

    private void UpdateAnimations()
    {
        if (!NøkkenIsSpawning)
        {
            _animator.Play("nøkken_Chase");
        }
    }
        
}
