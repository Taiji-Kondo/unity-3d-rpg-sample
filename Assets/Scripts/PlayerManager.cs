using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Animator _animator;
    private float _x;
    private float _z;
    private static readonly int MoveSpeed = Animator.StringToHash("MoveSpeed");
    
    public float moveSpeed = 3;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Move by keydown
        _x = Input.GetAxis("Horizontal");
        _z = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    { 
        // Move speed
        _rigidbody.velocity = new Vector3(_x, 0, _z) * moveSpeed;
        // Move animation
        _animator.SetFloat(MoveSpeed, _rigidbody.velocity.magnitude);
    }
}
