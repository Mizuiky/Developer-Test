using UnityEngine;
using System.Collections;

namespace Test.Characters
{
    public class SimpleCharacter : MonoBehaviour
    {
        [SerializeField] private SimpleCharacterData _data;
        [SerializeField] private Transform _stackPivot;

        private float _timeToMove;
        private float _elapsedTime;
        private bool _hasChangedPosition;
        private float _price;

        public bool HasChangedPosition { get { return _hasChangedPosition; } }
        public Transform Pivot { get { return _stackPivot; } }
        public float Price { get { return _price; } }

        public void Start()
        {
            Init();
        }

        private void Init()
        {
            _elapsedTime = 0f;
            _hasChangedPosition = false;
            _price = _data.characterValue;
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

        public void Sell()
        {
            transform.SetParent(null);
            //particle
            //audio
            Destroy(gameObject);
        }
    }
}