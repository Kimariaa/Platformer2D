using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerInput 
    {
        private PlayerController _controller;
        private Player _player;
        private bool _forward;
        private Vector2 _inputVector;

        public PlayerInput(Player player)
        {
            _player = player;
            _controller = new PlayerController();
            Bind();
        }

        private void Bind()
        {
            _controller.Player.Enable();

            _controller.Player.Move.started += OnMoveInput;
            _controller.Player.Move.canceled += OnMoveInput;
            _controller.Player.Jump.started += OnJumpInput;
            _controller.Player.Jump.canceled += OnJumpInput;
            _controller.Player.Fire.started += OnFireInput;
            _controller.Player.Fire.canceled += OnFireInput;
        }

        public void Expose()
        {
            _controller.Player.Disable();

            _controller.Player.Move.started -= OnMoveInput;
            _controller.Player.Move.canceled -= OnMoveInput;
            _controller.Player.Jump.started -= OnJumpInput;
            _controller.Player.Jump.canceled -= OnJumpInput;
            _controller.Player.Fire.started -= OnFireInput;
            _controller.Player.Fire.canceled -= OnFireInput;
        }

        private void OnFireInput(InputAction.CallbackContext context)
        {
            _player.SetJump(context.ReadValueAsButton());
        }

        private void OnJumpInput(InputAction.CallbackContext context)
        {
            _player.SetFire(context.ReadValueAsButton());
        }

        private void OnMoveInput(InputAction.CallbackContext context)
        {
            _inputVector = context.ReadValue<Vector2>();
            if (_inputVector.x > 0)
            {
                _forward = true;
            }
            else if(_inputVector.x < 0)
            {
                _forward = false;
            }

            _player.SetInput(_inputVector, _forward);
        }
    }
}

