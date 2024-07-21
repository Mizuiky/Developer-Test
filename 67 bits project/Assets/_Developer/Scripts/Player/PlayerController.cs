using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Test.Color;
using Test.Event;
using Test.Shop;

namespace Test.Characters
{
    public class PlayerController : PlayerCharacter
    {
        [SerializeField] private Transform _stackParent;
        [SerializeField] private GameEventObject _onColorUse;
        [SerializeField] private float _timeToSell;

        private Transform _pivot;
        private Stack<SimpleCharacter> _playerStack;
        private int _maxStackNumber;
     
        public Transform StackPosition { get { return _pivot; } }

        public void OnEnable()
        {
            _onColorUse.Subscribe(ChangeColor);
        }

        public override void Init()
        {
            _pivot = _stackParent;
            _maxStackNumber = _playerData.maxStackAmount;
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

        public void ChangeColor(object[] data)
        {
            _colorController.SetBodyColor((ColorItemData)data[0]);
        }

        #region PlayerStack

        public void IncreaseStackNumber(int amount)
        {
            _maxStackNumber = amount;
        }

        public void SetStackPosition(Transform newPivot)
        {
            _pivot = newPivot;
        }

        public bool AddToStack(SimpleCharacter character)
        {
            if (_playerStack.Count == _maxStackNumber) return false;
            _playerStack.Push(character);
            return true;
        }

        public void RemoveFromStack()
        {
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


        public void OnDisable()
        {
            _onColorUse.Unsubscribe(ChangeColor);
        }
    }
}