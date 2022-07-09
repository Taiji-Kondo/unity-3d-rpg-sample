using UnityEngine;

namespace Player
{
    public class PlayerHurtBehaviour : StateMachineBehaviour
    {
        private static readonly int Hurt = Animator.StringToHash("Hurt");

        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.ResetTrigger(Hurt);
            // Change moveSpeed to zero
            animator.GetComponent<PlayerManager>().moveSpeed = 0.4f;
            // Disable the player's collider
            animator.GetComponent<PlayerManager>().DisableWeaponCollider();
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        // public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        // {
        //     
        // }

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.ResetTrigger(Hurt);
            // reset moveSpeed
            animator.GetComponent<PlayerManager>().moveSpeed = 3;
        }

        // OnStateMove is called right after Animator.OnAnimatorMove()
        //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //    // Implement code that processes and affects root motion
        //}

        // OnStateIK is called right after Animator.OnAnimatorIK()
        //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //    // Implement code that sets up animation IK (inverse kinematics)
        //}
    }
}
