using Test.Characters;
using UnityEngine;

namespace Test.Store
{
    public class StackTrigger : MonoBehaviour
    {
        [SerializeField] private string _tagToCompare;
        private PlayerController _player;

        public void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag(_tagToCompare))
            {
                _player = other.gameObject.GetComponentInParent<PlayerController>();
                if (_player == null) return;
                _player.RemoveFromStack();
            }
        }
    }
}