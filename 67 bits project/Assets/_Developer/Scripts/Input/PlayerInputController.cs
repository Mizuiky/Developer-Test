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
        private PlayerCharacter _character;

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
            _character = GetComponent<PlayerCharacter>();

            _playerControls.Player.Move.performed += Move;
            _playerControls.Player.Move.canceled += CancelMovement;

            _playerControls.Player.Punch.performed += Punch;
        }

        private void Move(InputAction.CallbackContext context)
        {
            _direction = context.ReadValue<Vector2>();
            _character._components.movementController.SetInput(_direction);
        }

        private void CancelMovement(InputAction.CallbackContext context)
        {
            _direction = new Vector2(0f, 0f);
            _character._components.movementController.SetInput(_direction);
        }

        private void Punch(InputAction.CallbackContext context)
        {
            Debug.Log("Punch input");
            _character.Punch();
        }

        private void OnDisable()
        {
            _playerControls.Disable();
        }
    }
}