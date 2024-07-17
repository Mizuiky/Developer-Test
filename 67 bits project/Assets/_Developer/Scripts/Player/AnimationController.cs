using UnityEngine;

namespace Test.Animation
{
    public class AnimationController : MonoBehaviour
    {
        private Animator _animator;
        private int _velocityHash;

        public void Start()
        {
            _animator = GetComponentInChildren<Animator>();
            _velocityHash = Animator.StringToHash("velocity");
        }

        public void PlayWalkAnimation(float velocity)
        {
            _animator.SetFloat(_velocityHash, velocity);
        }
    }
}
