using Test.Characters;
using Test.Animation;
using UnityEngine;

namespace Test.Movement
{
    public class MovementController : MonoBehaviour
    {
        private CharacterData _data;
        private PlayerAnimationController _animationController;
        private Rigidbody _rb;
        private Quaternion _rotation;

        private Vector3 _direction;

        private float _speed;
        private float _acceleration;
        private float _deaceleration;

        private float _targetAngle;
        private float _currentVelocity;

        public void Init(CharacterComponents character)
        {
            _direction = Vector3.zero;
            _data = character.characterData;
            _animationController = character.animationBase.GetComponent<PlayerAnimationController>();
            _rb = character.rb;
        }

        public void Reset()
        {
            _direction = Vector3.zero;
        }

        public void SetInput(Vector2 input)
        {
            _direction = new Vector3(input.x, 0f, input.y).normalized;
        }

        public void Update()
        {
            SetCurrentSpeed();
            _animationController.PlayWalkAnimation(_speed);
        }

        private void SetCurrentSpeed()
        {
            if (_direction.magnitude > 0)
                _speed += _data.acceleration * Time.deltaTime;
            else
                _speed -= _data.deaceleration * Time.deltaTime;

            _speed = Mathf.Clamp(_speed, 0f, _data.maxSpeed);
                                                                       
        }

        public void FixedUpdate()
        {
            if (_direction.magnitude == 0) return;
 
            Rotate();

            Vector3 moveDirection = _direction * _speed;
            Move(moveDirection);           
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
