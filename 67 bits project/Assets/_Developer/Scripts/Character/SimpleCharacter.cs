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

        private float _timeToMove;
        private float _elapsedTime;
        private bool _hasChangedPosition;

        public bool HasChangedPosition { get { return _hasChangedPosition; } }
        public Transform Pivot { get { return _stackPivot; } }

        public void Start()
        {
            Init();
        }

        public void Init()
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

        public IEnumerator ChangePositionCoroutine()
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
    }
}