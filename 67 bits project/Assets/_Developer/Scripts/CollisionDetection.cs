using Test.Characters;
using UnityEngine;

namespace Test.CollisionDetection
{
    public class CollisionDetection : MonoBehaviour
    {
        [SerializeField] private string _tagToCompare;
        [SerializeField] private Collider _collider;

        public void OnCollisionEnter(Collision collision)
        {
            if(collision.collider.CompareTag(_tagToCompare))
            {
                var character = collision.collider.gameObject.GetComponent<SimpleCharacter>();
                if (character == null) return;
                character.Punch();
            }
        }

        public void OnCollisionExit(Collision collision)
        {
            _collider.enabled = false;
        }
    }
}