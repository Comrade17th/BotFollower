using System;
using UnityEngine;

namespace CodeBase
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        private readonly float _gravityFactor = 70;
        
        [SerializeField] private float _speed;

        private CharacterController _characterController;
        private InputService _inputService;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _inputService = new InputService();
        }

        private void Update()
        {
            Vector3 moveDirection = new Vector3(_inputService.Axis.x, 0, _inputService.Axis.y);
            moveDirection *= Time.deltaTime * _speed;

            var gravity = Vector3.down * _gravityFactor;
            
            if (_characterController.isGrounded)
                _characterController.Move(moveDirection + gravity * Time.deltaTime);
            else
                _characterController.Move(_characterController.velocity + gravity * Time.deltaTime);
        }
    }
}
