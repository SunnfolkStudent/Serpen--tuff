using UnityEngine;

public class NisseSpawner : MonoBehaviour
{
    public GameObject nisse;
    public AudioClip nisseNoise;

    private float _random;
    private AudioSource _audioSource;


    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (_random > 0)
        {
            _random -= Time.deltaTime;
        }
        else
        {
            Instantiate(nisse, transform.position, transform.rotation);
            _audioSource.PlayOneShot(nisseNoise);
            _random = Random.Range(0, 4);
        }
    }
}
