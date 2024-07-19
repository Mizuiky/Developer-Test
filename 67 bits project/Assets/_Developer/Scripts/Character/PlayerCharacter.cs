using Test.Animation;
using Test.Input;

namespace Test.Characters
{
    public class PlayerCharacter : CharacterBase
    {   
        private PlayerAnimationController _animationController;
        private PlayerInputController _inputController;

        public override void OnLoad()
        {
            _inputController = GetComponent<PlayerInputController>();
            _animationController = GetComponentInChildren<PlayerAnimationController>();

            base.OnLoad();
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