using UnityEngine;

namespace Player
{
    public class PlayerManager : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        private Animator _animator;
        private float _x;
        private float _z;
        private int _maxHp = 100;
        private int _hp;
        private static readonly int MoveSpeed = Animator.StringToHash("MoveSpeed");
        private static readonly int Attack = Animator.StringToHash("Attack");
        private static readonly int Hurt = Animator.StringToHash("Hurt");
    
        public float moveSpeed;
        public Collider weaponCollider;

        void Start()
        {
            _hp = _maxHp;
            
            _rigidbody = GetComponent<Rigidbody>();
            _animator = GetComponent<Animator>();
            
            DisableWeaponCollider();
        }

        void Update()
        {
            // Move by keydown
            _x = Input.GetAxis("Horizontal");
            _z = Input.GetAxis("Vertical");
        
            // Attack by keydown
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _animator.SetTrigger(Attack);
            }
        }

        private void FixedUpdate()
        { 
            // Move direction
            Vector3 direction = transform.position + new Vector3(_x, 0, _z) * moveSpeed;
            transform.LookAt(direction);
            // Move speed
            _rigidbody.velocity = new Vector3(_x, 0, _z) * moveSpeed;
            // Move animation
            _animator.SetFloat(MoveSpeed, _rigidbody.velocity.magnitude);
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
            }
            Debug.Log("HP: " + _hp);
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
