using UnityEngine;

public class NøkkenTrigger : MonoBehaviour
{
    public GameObject nøkkenTrigger;
    public GameObject nøkken;
    private float _randomX;
    private Vector2 _randomSpawn;
    

   
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            _randomX = Random.Range(-20f, 20f);
            if ((-10 < _randomX) && (10 > _randomX))
            {
                while ((-10 < _randomX) && (10 > _randomX))
                {
                    _randomX = Random.Range(-20f, 20f);
                    return;
                }
            }
            else
            {
                _randomSpawn = new Vector2(transform.position.x + _randomX, transform.position.y);
             Instantiate(nøkken, _randomSpawn, transform.rotation);
             nøkkenTrigger.SetActive(false);
            }
        }
    }
}
