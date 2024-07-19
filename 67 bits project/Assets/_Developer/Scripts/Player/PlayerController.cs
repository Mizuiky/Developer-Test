using UnityEngine;
using System.Collections.Generic;
using NUnit.Framework;

namespace Test.Characters
{
    public class PlayerController : PlayerCharacter
    {
        [SerializeField] private Transform _stackParent;
     
        private Transform _pivot;
        private Stack<SimpleCharacter> _playerStack;
        private int _stackCount = 0;
     
        public Transform StackPosition { get { return _pivot; } }
    
        public override void Init()
        {
            _stackCount = 0;
            _pivot = _stackParent;
            _playerStack = new Stack<SimpleCharacter>();
            base.Init();
        }

        public override void Reset()
        {
            base.Reset();
            _playerStack.Clear();
        }

        #region PlayerStack
        public void SetStackPosition(Transform newPivot)
        {
            _pivot = newPivot;
        }

        public void AddToStack(SimpleCharacter character)
        {
            _stackCount++;
            _playerStack.Push(character);
        }

        public SimpleCharacter RemoveFromStack(SimpleCharacter character)
        {
            return _playerStack.Pop();
        }
        #endregion
    }
}