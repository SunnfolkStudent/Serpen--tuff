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
    
    
    private Rigidbody2D _rigidbody2D;
    private AudioSource _audioSource;
    private int _soundTimer = 10;
    
  
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
        StartCoroutine(StompSound());
    }
    
    private void FixedUpdate()
    {
        _rigidbody2D.linearVelocityX = moveSpeed;
        
    }

    IEnumerator StompSound()
    {
        for (int i = 0; i < _soundTimer; i = 0)
        {
            _audioSource.PlayOneShot(stomp);
            yield return new WaitForSeconds(1f);
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
