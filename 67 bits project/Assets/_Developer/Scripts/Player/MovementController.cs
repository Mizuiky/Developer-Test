using Test.Characters;
using UnityEngine;

namespace Test.Movement
{
    public class MovementController : MonoBehaviour
    {
        private CharacterData _data;
        private Rigidbody _rb;

        private Vector3 _movementInput;
        private Vector3 _direction;

        private float _horizontal;
        private float _vertical;
        private float _speed;

        public void Init(CharacterComponents character)
        {
            _movementInput = Vector3.zero;
            _data = character.characterData;
            _rb = character.rb;
        }

        public void Reset()
        {
            _movementInput = Vector3.zero;
        }

        public void Update()
        {
            _horizontal = Input.GetAxis("Horizontal");
            _vertical = Input.GetAxis("Vertical");

            _movementInput = new Vector3(_horizontal, 0f, _vertical) * Time.deltaTime;
        }

        public void FixedUpdate()
        {
            if (_movementInput == Vector3.zero) return;

            _direction = _movementInput.normalized * _data.maxSpeed;
            Move(_direction);                    
        }

        private void Move(Vector3 velocity)
        {
            _rb.velocity = velocity;
        }
    }
}
