using System;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class EnemyManager : MonoBehaviour
    {
        private NavMeshAgent _agent;
        private Animator _animator;
        public int maxHp = 100;
        private int _hp;
        private static readonly int Distance = Animator.StringToHash("Distance");
        private static readonly int Hurt = Animator.StringToHash("Hurt");
        private static readonly int Die = Animator.StringToHash("Die");

        public Transform target;
        public Collider weaponCollider;
        public EnemyHpManager enemyHpManager;
        public GameObject gameClearText;

        void Start()
        {
            // Init
            _hp = maxHp;
            enemyHpManager.Init(this);
            
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
                Damage(weapon.damage);
            }
        }
        
        private void Damage(int damage)
        {
            _hp -= damage;
            if (_hp <= 0)
            {
                _hp = 0;
                
                _animator.SetTrigger(Die);
                gameClearText.SetActive(true);
            }
            enemyHpManager.UpdateHp(_hp);
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
