using Test.Characters;
using Unity.VisualScripting;
using UnityEngine;

namespace Test.Movement
{
    public class MovementController : MonoBehaviour
    {
        private CharacterData _data;
        private Rigidbody _rb;
        private Quaternion _rotation;

        private Vector3 _direction;

        private float _horizontal;
        private float _vertical;
        private float _speed;
        private float _targetAngle;
        private float _currentVelocity;

        public void Init(CharacterComponents character)
        {
            _direction = Vector3.zero;
            _data = character.characterData;
            _rb = character.rb;
        }

        public void Reset()
        {
            _direction = Vector3.zero;
        }

        public void Update()
        {
            _horizontal = Input.GetAxis("Horizontal");
            _vertical = Input.GetAxis("Vertical");

            _direction = new Vector3(_horizontal, 0f, _vertical).normalized;
        }

        public void FixedUpdate()
        {
            if (_direction.magnitude == 0) return;
 
            Rotate();

            _direction *= _data.maxSpeed * Time.deltaTime;      
            Move(_direction);           
        }

        private void Move(Vector3 velocity)
        {
            _rb.velocity = velocity;
        }

        private void Rotate()
        {
            if (_direction != Vector3.zero)
            {
                _targetAngle = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg;
                var angle = Mathf.SmoothDampAngle(transform.rotation.eulerAngles.y, _targetAngle, ref _currentVelocity, _data.rotationSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
            }
        }
    }
}
