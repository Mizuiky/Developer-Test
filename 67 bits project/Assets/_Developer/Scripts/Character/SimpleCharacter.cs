using UnityEngine;
using System.Collections;
using UnityEngine.UIElements;
using Unity.VisualScripting;

namespace Test.Characters
{
    public class SimpleCharacter : MonoBehaviour
    {
        [SerializeField] private SimpleCharacterData _data;

        private float _timeToMove;
        private float _elapsedTime;
        private bool _hasChangedPosition;
        private Vector3 _position;
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

        public void ChangePosition(Transform parent, Transform destination)
        {
            Debug.Log("Change Position");
            _hasChangedPosition = true;
            transform.SetParent(parent, false);
            _position = destination.position;
            StartCoroutine(ChangePositionCoroutine(destination.localPosition));
        }

        public IEnumerator ChangePositionCoroutine(Vector3 destination)
        {
            while(_elapsedTime < _data.timeToMove)
            {
                Debug.Log(_elapsedTime);
                _elapsedTime += Time.deltaTime;
                transform.localPosition = Vector3.Lerp(transform.localPosition, destination, _elapsedTime / _data.timeToMove);           
                yield return null;
            }

            Debug.Log("depois de finalizar");
            transform.position = _position;          
        }
    }
}