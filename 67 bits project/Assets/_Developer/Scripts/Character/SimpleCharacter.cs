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
            StartCoroutine(ChangePositionCoroutine(parent.localPosition));
        }

        //Quickly do the lerp - other time try to make it work better, but it is equal to the noodle run
        private IEnumerator ChangePositionCoroutine(Vector3 destination)
        {
            destination.y = 0f;
            while(_elapsedTime < _data.timeToMove)
            {
                _elapsedTime += Time.deltaTime;
                transform.localPosition = Vector3.Lerp(transform.localPosition, destination, _elapsedTime / _data.timeToMove);           
            }
            yield return null;
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