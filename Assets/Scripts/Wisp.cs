using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Wisp : MonoBehaviour
{
    [SerializeField] private float _speed, _lifeTime;
    [SerializeField] private Rigidbody2D _rigidbody;

    private void Awake()
    {
        if(_rigidbody == null)
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }
    }

    public void Init(Vector3 position, bool direction)
    {
        gameObject.SetActive(true);
        transform.position = position;
        transform.rotation = direction ? Quaternion.identity : Quaternion.Euler(0, 0, 180);

        ApplyForce();
        StartCoroutine(DeactivateCoroutine());
    }

    private IEnumerator DeactivateCoroutine()
    {
        yield return new WaitForSeconds(_lifeTime);

        gameObject.SetActive(false);
    }

    private void ApplyForce()
    {
        _rigidbody.velocity = transform.right * _speed;
    }
}
