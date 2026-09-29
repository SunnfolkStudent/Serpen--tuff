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
    
    IEnumerator StompFar()
    {
        audioFarActive = true;
        _audioSource.volume = 0.3f;
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
        _audioSource.volume = 0.6f;
        while (audioMediumActive)
        {
            _audioSource.PlayOneShot(stomp);
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator StompNear()
    {
        audioNearActive = true;
        _audioSource.volume = 1f;
        while (audioNearActive)
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

        if ((Vector2.Distance(transform.position, _target.position) < sightRangeFar)
            && (Vector2.Distance(transform.position, _target.position) > sightRangeMedium)
            && !audioFarActive && !audioMediumActive && !audioFarActive )
        {
           
            StopCoroutine(StompMedium());
            audioMediumActive = false;
            audioNearActive = false;
            StartCoroutine(StompFar());
        } 
        else if ((Vector2.Distance(transform.position, _target.position) < sightRangeMedium)
                 && (Vector2.Distance(transform.position, _target.position) > sightRangeNear)
                 && !audioMediumActive && !audioNearActive)
        {
           
                StopCoroutine(StompFar());
                StopCoroutine(StompNear());
                audioFarActive = false;
                audioNearActive = false;
                StartCoroutine(StompMedium());
        }
        else if ((Vector2.Distance(transform.position, _target.position) < sightRangeNear) && !audioNearActive) 
        {
            StopCoroutine(StompMedium());
            audioMediumActive = false;
            audioFarActive = false;
            StartCoroutine(StompNear());
        }

        if ((Vector2.Distance(transform.position, _target.position) > sightRangeNear) 
            && Vector2.Distance(transform.position, _target.position) < sightRangeMedium
            && audioNearActive)
        {
            audioNearActive = false;
            StopCoroutine(StompNear());
        }
        else if ((Vector2.Distance(transform.position, _target.position) > sightRangeMedium)
                 && (Vector2.Distance(transform.position, _target.position) < sightRangeFar)
                 && audioMediumActive)
        {
            audioMediumActive = false;
            StopCoroutine(StompMedium());
        }
        else if (Vector2.Distance(transform.position, _target.position) > sightRangeFar)
        {
            audioFarActive = false;
            StopCoroutine(StompFar());
        }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(wallCheck.position, 0.1f);
        Gizmos.color = Color.chartreuse;
        Gizmos.DrawWireSphere(transform.position, sightRangeFar);
        Gizmos.color = Color.aquamarine;
        Gizmos.DrawWireSphere(transform.position, sightRangeMedium);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, sightRangeNear);
        
    }


}
