using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private float _x;
    private float _z;
    public float moveSpeed = 3;
    
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
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
    }
}
