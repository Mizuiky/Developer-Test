using UnityEngine;
using System.Collections;

namespace Test.Characters
{
    public class SimpleCharacter : MonoBehaviour
    {
        [SerializeField] private Transform _characterPivot;
        [SerializeField] private SimpleCharacterData _data;

        private float _timeToMove;
        private float _elapsedTime;
        private bool _hasChangedPosition;

        public Transform Pivot { get { return _characterPivot; } }
        public bool HasChangedPosition { get { return _hasChangedPosition; } }

        public void Start()
        {
            Init();
        }

        public void Init()
        {
            _elapsedTime = 0f;
            _hasChangedPosition = false;
        }

        public void ChangePosition(Transform destination)
        {
            Debug.Log("Change Position");
            _hasChangedPosition = true;
            transform.SetParent(destination, false);
            StartCoroutine(ChangePositionCoroutine(destination.localPosition));
        }

        public IEnumerator ChangePositionCoroutine(Vector3 destination)
        {
            while(_elapsedTime < _data.timeToMove)
            {
                _elapsedTime += Time.deltaTime;
                transform.localPosition = Vector3.Lerp(_characterPivot.localPosition, destination, _elapsedTime / _data.timeToMove);
            }
               
            transform.localPosition = Vector3.zero;
            yield return null;
        }
    }
}