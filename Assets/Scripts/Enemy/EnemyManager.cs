using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class EnemyManager : MonoBehaviour
    {
        private NavMeshAgent _agent;

        public Transform target;
        
        void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            _agent.destination = target.position;
        }

        void Update()
        {
            _agent.destination = target.position;
        }
    }
}
