using System;
using UnityEngine;

public class PestaSpawn : MonoBehaviour
{
    public GameObject pesta;

    public float pestaTimer;


    private void Update()
    {
        if (pestaTimer > 0)
        {
            pestaTimer -= Time.deltaTime;
        }
        else
        {
            Instantiate(pesta, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
