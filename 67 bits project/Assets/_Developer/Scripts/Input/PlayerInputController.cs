using Test.Movement;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    private Vector2 _direction;
    private PlayerControls _playerControls;
    private MovementController _movementController;

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
        _movementController = GetComponent<MovementController>();

        _playerControls.Player.Move.performed += Move;
        _playerControls.Player.Move.canceled += CancelMovement;

        _playerControls.Player.Punch.performed += Punch;
    }

    private void Move(InputAction.CallbackContext context)
    {
        _direction = context.ReadValue<Vector2>();
        _movementController.SetInput(_direction);
    }

    private void CancelMovement(InputAction.CallbackContext context)
    {
        _direction = new Vector2(0f, 0f);
        _movementController.SetInput(_direction);
    }

    private void Punch(InputAction.CallbackContext context)
    {

    }

    private void OnDisable()
    {
        _playerControls.Disable();
    }
}
