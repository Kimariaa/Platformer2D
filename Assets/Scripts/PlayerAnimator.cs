using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerAnimator
    {
        private readonly int _speedHash = Animator.StringToHash("Speed");
        private readonly int _groundedHash = Animator.StringToHash("Grounded");
        private readonly int _deathHash = Animator.StringToHash("Death");

        private Animator _animator;

        public PlayerAnimator(Animator animator)
        {
            _animator = animator;
        }

        public void SetGrounded(bool isGrounded)
        {
            _animator.SetBool(_groundedHash, isGrounded);
        }

        public void SetMove( float inputX)
        {
            _animator.SetFloat(_speedHash, Mathf.Abs(inputX));
        }
    }
}
