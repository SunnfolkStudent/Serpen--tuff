using UnityEngine;
using System.Collections;

public class TrollEnemy : MonoBehaviour
{
    public float moveSpeed;

    public LayerMask whatIsWall;
    public Transform wallCheck;
    public AudioClip stomp;
    public float sightRangeFar;
    public float sightRangeMedium;
    public float sightRangeNear;
    public bool audioFarActive = false;
    public bool audioMediumActive = false;
    public bool audioNearActive = false;
    public CircleCollider2D stompFar;
    public CircleCollider2D stompMedium;
    public CircleCollider2D stompNear;

    private Transform _target;
    private Rigidbody2D _rigidbody2D;
    private AudioSource _audioSource;
    private int _soundTimer = 10;
    
  
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
        _target = GameObject.Find("Player").transform;
        
    }
    
    private void FixedUpdate()
    {
        _rigidbody2D.linearVelocityX = moveSpeed;
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (CompareTag("Player"))
        {
            
        }
    }

    IEnumerator StompFar()
    {
        audioFarActive = true;

        while (audioFarActive)
        {
            _audioSource.PlayOneShot(stomp);
            yield return new WaitForSeconds(2f);
            yield return null;
        }



    }

    IEnumerator StompMedium()
    {
        audioMediumActive = true;
        for (int i = 0; i < _soundTimer; i = 0)
        {
            _audioSource.PlayOneShot(stomp);
            yield return new WaitForSeconds(1f);
        } 
    }

    IEnumerator StompNear()
    {
        audioNearActive = true;
        for (int i = 0; i < _soundTimer; i = 0)
        {
            _audioSource.PlayOneShot(stomp);
            yield return new WaitForSeconds(0.5f);
        } 
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
            transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y);
        }

        /*if ((Vector2.Distance(transform.position, _target.position) < sightRangeFar) && !audioFarActive && !audioMediumActive && !audioFarActive )
        {
            StartCoroutine(StompFar());
           
        } 
        else if ((Vector2.Distance(transform.position, _target.position) < sightRangeMedium) && !audioMediumActive)
        {
            audioFarActive = false;
                StopCoroutine(StompFar());
                StartCoroutine(StompMedium());
            
        }
        else if ((Vector2.Distance(transform.position, _target.position) < sightRangeNear) &&!audioNearActive) 
        { 
            StopCoroutine(StompMedium());
            StartCoroutine(StompNear());
        }*/
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(wallCheck.position, 0.1f);
        /*Gizmos.color = Color.chartreuse;
        Gizmos.DrawWireSphere(stompFar.transform.position, 4);
        Gizmos.color = Color.aquamarine;
        Gizmos.DrawWireSphere(stompMedium.transform.position, 3);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(stompNear.transform.position, 2);
        */
        
    }


}
