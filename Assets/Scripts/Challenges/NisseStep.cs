using System;
using System.Collections;
using UnityEngine;

public class NisseStep : MonoBehaviour
{
    public AudioClip StepSound;
    public AudioClip NisseSound;
    public Rigidbody2D nisseSpotter;
    public float moveSpeed = 0;
    public Animator nisseAnimator;
    public Rigidbody2D playerRigidbody;
    
    private AudioSource _audioSource;


    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
       
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            StartCoroutine(Nisse());
        }
    }

    private IEnumerator Nisse()
    {
        playerRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        _audioSource.PlayOneShot(NisseSound);
        yield return new WaitForSeconds(NisseSound.length);
        _audioSource.PlayOneShot(StepSound);
        moveSpeed = 1;
        yield return new WaitForSeconds(StepSound.length);
        playerRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        nisseSpotter.linearVelocity = new Vector2(moveSpeed, nisseSpotter.linearVelocity.y);
        if (moveSpeed == 0)
        {
            nisseAnimator.Play("still/idle_L");
        }
        else
        {
            nisseAnimator.Play("run_R");
        }
    }
}
