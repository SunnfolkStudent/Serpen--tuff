using UnityEngine;

public class NisseSpawner : MonoBehaviour
{
    public GameObject nisse;
    
    
    private float i = 3;

    
    private void Update()
    {
        if (i > 0)
        {
            i -= Time.deltaTime;
        }
        else
        {
            Instantiate(nisse, transform.position, transform.rotation);
            i = 3;
        }
    }
}
