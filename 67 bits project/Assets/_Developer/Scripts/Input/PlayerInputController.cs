using Test.Characters;
using Test.Movement;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Test.Input
{
    public class PlayerInputController : MonoBehaviour
    {
        private Vector2 _direction;
        private PlayerControls _playerControls;
        private PlayerController _player;

        private void Awake()
        {
            _playerControls = new PlayerControls();
        }

        private void OnEnable()
        {
            _playerControls.Enable();
        }

        public void Init()
        {
            _player = GetComponent<PlayerController>();

            _playerControls.Player.Move.performed += Move;
            _playerControls.Player.Move.canceled += CancelMovement;

            _playerControls.Player.Punch.performed += Punch;
        }

        private void Move(InputAction.CallbackContext context)
        {
            _direction = context.ReadValue<Vector2>();
            _player._components.movementController.SetInput(_direction);
        }

        private void CancelMovement(InputAction.CallbackContext context)
        {
            _direction = new Vector2(0f, 0f);
            _player._components.movementController.SetInput(_direction);
        }

        private void Punch(InputAction.CallbackContext context)
        {
            _player.Punch();
        }

        private void OnDisable()
        {
            _playerControls.Disable();
        }
    }
}