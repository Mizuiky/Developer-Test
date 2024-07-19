using UnityEngine;

namespace Test.Animation
{
    public class AnimationBase : MonoBehaviour
    {
        protected Animator _animator;

        public void Awake()
        {
            Init();
        }

        public virtual void Init()
        {
            _animator = GetComponentInChildren<Animator>();
        }
    }
}