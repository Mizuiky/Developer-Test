using UnityEngine;

namespace Test.Animation
{
    public class PlayerAnimationController : AnimationBase
    {
        private int _velocityHash;
        private int _punchHand;
        private int _punchPerformed;
        private int _hand;

        public override void Init()
        {
            base.Init();
            _velocityHash = Animator.StringToHash("velocity");
            _punchHand = Animator.StringToHash("punchHand");
            _punchPerformed = Animator.StringToHash("punchPerformed");
            _hand = 1;

            HasPunchPerformed();          
        }

        public void PlayWalkAnimation(float velocity)
        {
            _animator.SetFloat(_velocityHash, velocity);
        }

        public void PlayPunchAnimation()
        {
            _animator.SetBool(_punchPerformed, true);
            _animator.SetInteger(_punchHand, _hand);

            if (_hand == 0)
                _hand = 1;
            else
                _hand = 0;
        }

        public void HasPunchPerformed()
        {
            _animator.SetBool(_punchPerformed, false);
        }
    }
}
