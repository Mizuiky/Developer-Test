using Test.Animation;
using Test.Input;
using UnityEngine;

namespace Test.Characters
{
    public class PlayerCharacter : CharacterBase
    {
        [SerializeField] private PlayerData _playerData;
        private PlayerAnimationController _animationController;
        private PlayerInputController _inputController;

        public override void OnLoad()
        {
            base.OnLoad();
            _inputController = GetComponent<PlayerInputController>();
            _animationController = GetComponentInChildren<PlayerAnimationController>();
            _components.movementController.SetData(_playerData);         
        }

        public override void Init()
        {
            _inputController.Init();
        }

        public void Punch()
        {           
            _animationController.PlayPunchAnimation();                                            
        }
    }
}