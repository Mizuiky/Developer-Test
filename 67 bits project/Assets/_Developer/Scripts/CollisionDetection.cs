using Test.Characters;
using UnityEngine;

namespace Test.CollisionDetection
{
    public class CollisionDetection : MonoBehaviour
    {
        [SerializeField] private string _tagToCompare;
        [SerializeField] private Collider _collider;
        [SerializeField] private PlayerController _playerController;

        public void Awake()
        {
            _playerController = GetComponentInParent<PlayerController>();
        }

        public void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.CompareTag(_tagToCompare))
            {
                var character = collision.collider.gameObject.GetComponentInParent<SimpleCharacter>();
                if (character == null || character.HasChangedPosition) return;

                character.ChangePosition(_playerController.StackPosition);
                _playerController.SetStackPosition(character.Pivot);
                _playerController.AddToStack(character);
                character._onCharacterAmountChanged?.InvokeEvent();
            }
        }
    }
}