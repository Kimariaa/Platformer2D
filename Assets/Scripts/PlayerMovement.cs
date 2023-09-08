using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerMovement 
    {
        private Rigidbody2D _rigidbody;
        private float _jumpForce;

        public PlayerMovement(Rigidbody2D rigidbody)
        {
            _rigidbody = rigidbody;
        }

        public void Move(float inputX)
        {
            _rigidbody.velocity = new Vector2(inputX, _rigidbody.velocity.y);
        }

        public void Jump(bool jumping, bool grounded, float force)
        {
            if (jumping && grounded)
            {
                _rigidbody.AddForce(Vector2.up * force, ForceMode2D.Impulse);
            }
        }
    }
}

