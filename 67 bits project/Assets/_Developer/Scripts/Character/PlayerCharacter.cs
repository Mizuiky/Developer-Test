using System.Diagnostics;
using Test.Animation;
using Test.Input;

namespace Test.Characters
{
    public class PlayerCharacter : CharacterBase
    {   
        private PlayerAnimationController _animationController;
        private PlayerInputController _inputController;
        private bool rightHandPunch = true;

        public override void OnLoad()
        {
            _inputController = GetComponent<PlayerInputController>();
            _animationController = GetComponent<PlayerAnimationController>();

            base.OnLoad();
        }

        public override void Init()
        {
            _inputController.Init();
        }

        public void Punch()
        {
            _animationController.PlayPunchAnimation(rightHandPunch);

            if (rightHandPunch)
                rightHandPunch = false;
            else
                rightHandPunch = true;
        }
    }
}