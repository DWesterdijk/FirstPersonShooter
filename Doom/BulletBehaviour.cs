using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    /// <summary>
    /// This script takes care of the bullet.
    /// It will make sure that the bullet travels
    /// and that it gets destroyed after a few seconds.
    /// </summary>
    private Rigidbody _rigidbody;
    [SerializeField]
    private float _speed;


    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        Destroy(gameObject, 2f);
    }
    void FixedUpdate()
    {
        Vector3 velocity = transform.forward * _speed * Time.fixedDeltaTime;
        _rigidbody.MovePosition(_rigidbody.position + velocity);
    }
}
