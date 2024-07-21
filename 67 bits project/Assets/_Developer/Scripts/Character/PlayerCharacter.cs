using Test.Animation;
using Test.Color;
using Test.Input;
using UnityEngine;

namespace Test.Characters
{
    public class PlayerCharacter : CharacterBase
    {
        [SerializeField] private PlayerData _playerData;

        protected PlayerAnimationController _animationController;
        protected ColorController _colorController;
        private PlayerInputController _inputController;

        public override void OnLoad()
        {
            base.OnLoad();
            _inputController = GetComponent<PlayerInputController>();
            _animationController = GetComponentInChildren<PlayerAnimationController>();
            _colorController = GetComponentInChildren<ColorController>();
            _components.movementController.SetData(_playerData);         
        }

        public override void Init()
        {
            _inputController.Init();
        }
    }
}