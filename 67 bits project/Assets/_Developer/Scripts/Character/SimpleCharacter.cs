using UnityEngine;
using System.Collections;
using Test.Event;

namespace Test.Characters
{
    public class SimpleCharacter : MonoBehaviour
    {
        [SerializeField] private SimpleCharacterData _data;
        [SerializeField] private Transform _stackPivot;

        public GameEvent _onCharacterAmountChanged;
        public GameEventObject _onCharacterSold;

        private float _timeToMove;
        private float _elapsedTime;
        private bool _hasChangedPosition;

        public bool HasChangedPosition { get { return _hasChangedPosition; } }
        public Transform Pivot { get { return _stackPivot; } }

        public void Start()
        {
            Init();
        }

        private void Init()
        {
            _elapsedTime = 0f;
            _hasChangedPosition = false;
        }

        public void ChangePosition(Transform parent)
        {
            _hasChangedPosition = true;
            transform.SetParent(parent, false);
            StartCoroutine(ChangePositionCoroutine());
        }

        private IEnumerator ChangePositionCoroutine()
        {
            while(_elapsedTime < _data.timeToMove)
            {
                Debug.Log(_elapsedTime);
                _elapsedTime += Time.deltaTime;
                transform.localPosition = Vector3.Lerp(transform.localPosition, Vector3.zero, _elapsedTime / _data.timeToMove);           
                yield return null;
            }

            transform.localPosition = Vector3.zero;          
        }

        public void SellCharacter()
        {
            transform.SetParent(null);
            //particle
            //audio
            _onCharacterSold.Invoke(_data.characterValue);
            Destroy(gameObject);
        }
    }
}