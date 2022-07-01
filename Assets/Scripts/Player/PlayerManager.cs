using UnityEngine;

namespace Player
{
    public class PlayerManager : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        private Animator _animator;
        private float _x;
        private float _z;
        private static readonly int MoveSpeed = Animator.StringToHash("MoveSpeed");
        private static readonly int Attack = Animator.StringToHash("Attack");
    
        public float moveSpeed;

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
    }
}
