using System;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class EnemyManager : MonoBehaviour
    {
        private NavMeshAgent _agent;
        private Animator _animator;
        private static readonly int Distance = Animator.StringToHash("Distance");

        public Transform target;

        void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            _agent.destination = target.position;
            
            _animator = GetComponent<Animator>();
        }

        void Update()
        {
            _agent.destination = target.position;
            
            _animator.SetFloat(Distance, _agent.remainingDistance);
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Trigger Player Attack");
        }
    }
}
