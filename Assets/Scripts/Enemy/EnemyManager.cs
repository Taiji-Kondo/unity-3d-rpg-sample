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
        private static readonly int Hurt = Animator.StringToHash("Hurt");

        public Transform target;
        public Collider weaponCollider;

        void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            _agent.destination = target.position;
            
            _animator = GetComponent<Animator>();
            
            DisableWeaponCollider();
        }

        void Update()
        {
            _agent.destination = target.position;
            
            _animator.SetFloat(Distance, _agent.remainingDistance);
        }

        private void OnTriggerEnter(Collider other)
        {
            Weapon weapon = other.GetComponent<Weapon>();
            if (weapon != null)
            {
                _animator.SetTrigger(Hurt);
            }
        }
        
        public void DisableWeaponCollider()
        {
            weaponCollider.enabled = false;
        }
        
        public void EnableWeaponCollider()
        {
            weaponCollider.enabled = true;
        }
    }
}
