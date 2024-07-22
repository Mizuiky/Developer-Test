using System.Collections;
using System.Collections.Generic;
using Test.Event;
using Test.Shop;
using Test.SOValue;
using UnityEngine;

namespace Test.Characters
{
    public class PlayerController : PlayerCharacter
    {
        [SerializeField] private Transform _stackParent;

        [SerializeField] private GameEventObject _onColorUse;

        [SerializeField] private SoInt _currentCharacterQtd;
        [SerializeField] private SoInt _maxCharacterQtd;
        [SerializeField] private SoFloat _playerMoney;

        [SerializeField] private float _timeToSell;

        private Transform _pivot;
        private Stack<SimpleCharacter> _playerStack;
        private Stack<Transform> _stackPivot;

        public Transform StackPosition { get { return _pivot; } }

        public void OnEnable()
        {
            _onColorUse.Subscribe(ChangeColor);
        }

        public override void Init()
        {
            _pivot = _stackParent;
            _currentCharacterQtd.value = 0;
            _maxCharacterQtd.value = _playerData.initialMaxCharacterAmount;
            _playerMoney.value = 0f;
            _playerStack = new Stack<SimpleCharacter>();
            _stackPivot = new Stack<Transform>();
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

        public void IncreaseCurrentCharacterQtd(bool increased)
        {
            if(increased)
                _currentCharacterQtd.value++;
            else
                _currentCharacterQtd.value--;
        }

        public void SetStackPosition(Transform newPivot)
        {
            _pivot = newPivot;
            if(_stackPivot.Count == 0)
            {
                _stackPivot.Push(_stackParent);
                return;
            }
            _stackPivot.Push(_pivot);
        }

        public bool AddToStack(SimpleCharacter character)
        {
            if (_playerStack.Count == _maxCharacterQtd.value) return false;
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
                var character = _playerStack.Pop();
                _pivot = _stackPivot.Pop();
                _playerMoney.value += character.Price;
                character.Sell();
                IncreaseCurrentCharacterQtd(false);         
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