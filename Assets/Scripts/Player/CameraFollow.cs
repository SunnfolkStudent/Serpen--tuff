using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    private bool NisseArena = false;
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void LateUpdate()
    {
        if  (!NisseArena)
        {
            transform.position = new Vector3(target.position.x + 4f, target.position.y + 4f, -10);
        }
        else if (NisseArena)
        {
            transform.position = new Vector3(target.position.x, target.position.y + 6f, -10);
            

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("NisseTrigger"))
        {
            NisseArena = true;
            _camera.orthographicSize = 8;
            
        }
    }
}
