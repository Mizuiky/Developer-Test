using UnityEngine;

namespace Test.Characters
{
    public class PlayerController : PlayerCharacter
    {
        [SerializeField] private Transform _characterStackParent;
        public Transform StackPivot { get { return _characterStackParent; } } 
    }
}