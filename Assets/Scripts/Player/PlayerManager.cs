using UnityEngine;

namespace Player
{
    public class PlayerManager : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        private Animator _animator;
        private float _x;
        private float _z;
        public int maxHp = 100;
        private int _hp;
        private bool _isDie;
        private static readonly int MoveSpeed = Animator.StringToHash("MoveSpeed");
        private static readonly int Attack = Animator.StringToHash("Attack");
        private static readonly int Hurt = Animator.StringToHash("Hurt");
        private static readonly int Die = Animator.StringToHash("Die");
    
        public float moveSpeed;
        public Collider weaponCollider;
        public PlayerHpManager playerHpManager;
        public GameObject gameOverText;

        void Start()
        {
            // Init
            _hp = maxHp;
            playerHpManager.Init(this);
            
            _rigidbody = GetComponent<Rigidbody>();
            _animator = GetComponent<Animator>();
            
            DisableWeaponCollider();
        }

        void Update()
        {
            if (_isDie)
            {
                return;
            }
            
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
            if (_isDie)
            {
                return;
            }
            
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
            if (_isDie)
            {
                return;
            }
            
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
                _isDie = true;

                _rigidbody.velocity = Vector3.zero;
                _animator.SetTrigger(Die);
                gameOverText.SetActive(true);
            }
            playerHpManager.UpdateHp(_hp);
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
