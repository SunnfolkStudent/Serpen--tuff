using System;
using System.Collections;
using UnityEngine;

public class NisseStep : MonoBehaviour
{
    public AudioClip StepSound;
    public AudioClip NisseSound;
    public Rigidbody2D nisseSpotter;
    public float moveSpeed;
    
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
        _audioSource.PlayOneShot(NisseSound);
        yield return new WaitForSeconds(NisseSound.length);
        _audioSource.PlayOneShot(StepSound);
        moveSpeed = 1;
        yield return new WaitForSeconds(StepSound.length + 4);
        gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        nisseSpotter.velocity = new Vector2(moveSpeed, nisseSpotter.velocity.y);
    }
}
