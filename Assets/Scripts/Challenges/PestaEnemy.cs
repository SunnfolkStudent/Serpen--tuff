using System.Collections;
using UnityEngine;

public class PestaEnemy : MonoBehaviour
{
    public float moveSpeed;

    private Vector3 _attackDirection;
    private Transform _target;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        StartCoroutine(Spawn());
        
    }

    private void Update()
    {
        _attackDirection = Vector3.Normalize(_target.position - transform.position);

        transform.position += _attackDirection * (moveSpeed * Time.deltaTime);
    }

    private IEnumerator Spawn()
    {
        _animator.Play("spawn");
        yield return new WaitForSeconds(1.5f);
        _target = GameObject.Find("Player").transform;
        _animator.Play("follow/walk");
    }
}
