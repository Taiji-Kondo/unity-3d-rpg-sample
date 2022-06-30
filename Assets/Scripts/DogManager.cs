using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogManager : MonoBehaviour
{
    private Animator _animator;
    private static readonly int Attack = Animator.StringToHash("Attack");
    private static readonly int MoveSpeed = Animator.StringToHash("MoveSpeed");

    void Start()
    {
        _animator = GetComponent<Animator
        >();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _animator.SetTrigger(Attack);
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            _animator.SetFloat(MoveSpeed, 1);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            _animator.SetFloat(MoveSpeed, 0);
        }
    }
    
    public void Hit()
    {
        Debug.Log("Hit!!");
    }
}
