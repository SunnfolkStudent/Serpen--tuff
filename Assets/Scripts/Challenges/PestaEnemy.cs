using UnityEngine;

public class PestaEnemy : MonoBehaviour
{
    public float moveSpeed;

    private Vector3 _attackDirection;
    private Transform _target;

    private void Start()
    {
        _target = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        _attackDirection = Vector3.Normalize(_target.position - transform.position);

        transform.position += _attackDirection * (moveSpeed * Time.deltaTime);
    }
}
