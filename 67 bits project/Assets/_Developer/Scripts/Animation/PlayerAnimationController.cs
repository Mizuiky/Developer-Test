using UnityEngine;

namespace Test.Animation
{
    public class PlayerAnimationController : AnimationBase
    {
        private int _velocityHash;
        private int _punchLeftTrigger;
        private int _punchRightTrigger;

        public override void Init()
        {
            base.Init();
            _velocityHash = Animator.StringToHash("velocity");
            _punchLeftTrigger = Animator.StringToHash("punchLeft");
            _punchRightTrigger = Animator.StringToHash("punchRight");
        }

        public void PlayWalkAnimation(float velocity)
        {
            _animator.SetFloat(_velocityHash, velocity);
        }

        public void PlayPunchAnimation(bool rightHand)
        {
            if(rightHand)
            {
                _animator.SetTrigger(_punchRightTrigger);
                return;
            }
            _animator.SetTrigger(_punchLeftTrigger);
        }
    }
}
