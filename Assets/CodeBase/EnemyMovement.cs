using System;
using System.Collections;
using System.Collections.Generic;
using CodeBase;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyMovement : MonoBehaviour
{
    private readonly float gravityFactor = -2f;
    
    [SerializeField] private Transform _followTarget;
    [SerializeField] private float _followOffset = 2;
    [SerializeField] private float _speed = 3f;

    private Rigidbody _rigidbody;

    private void Awake() => 
        _rigidbody = GetComponent<Rigidbody>();

    private void FixedUpdate()
    {
        Vector3 heading = _followTarget.position - transform.position;
        Vector3 direction = heading.normalized;
        direction.y = 0;
        
        Vector3 gravity = new Vector3(0, gravityFactor, 0);
        
        if (heading.sqrMagnitude > _followOffset * _followOffset)
        {
            _rigidbody.velocity = _speed * direction;
            _rigidbody.velocity += gravity;
        }
        else
        {
            _rigidbody.velocity = Vector3.zero;
        }
    }
    
}
