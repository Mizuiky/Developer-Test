using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Test.Color;

namespace Test.Characters
{
    public class PlayerController : PlayerCharacter
    {
        [SerializeField] private Transform _stackParent;
        [SerializeField] private float _timeToSell;

        private Transform _pivot;
        private Stack<SimpleCharacter> _playerStack;
     
        public Transform StackPosition { get { return _pivot; } }
    
        public override void Init()
        {
            _pivot = _stackParent;
            _playerStack = new Stack<SimpleCharacter>();
            base.Init();
        }

        public override void Reset()
        {
            base.Reset();
            _playerStack.Clear();
        }

        public void Punch()
        {
            _animationController.PlayPunchAnimation();
        }

        public void ChangeColor(ColorDataType type, ColorData data, int colorIndex)
        {
            _colorController.SetColor(type, data, colorIndex);
        }

        #region PlayerStack
        public void SetStackPosition(Transform newPivot)
        {
            _pivot = newPivot;
        }

        public void AddToStack(SimpleCharacter character)
        {
            _playerStack.Push(character);
        }

        public void RemoveFromStack()
        {
            Debug.Log("stack number = " + _playerStack.Count);
            if (_playerStack.Count == 0) return;
            StartCoroutine(RemoveFromStackCoroutine());                  
        }

        private IEnumerator RemoveFromStackCoroutine()
        {
            while (_playerStack.Count > 0)
            {
               _playerStack.Pop().SellCharacter();
                yield return new WaitForSeconds(_timeToSell);
            }
        }

        #endregion
    }
}