using UnityEngine;
using Test.Movement;

namespace Test.Characters
{
    public class CharacterComponents
    {
        public Rigidbody rb { get; private set; }
        public AnimatorController animatorController { get; private set; }
        public MovementController movementController { get; private set; }
        public CharacterBase character { get; private set; }
        public  CharacterData characterData { get; private set; }

        public CharacterComponents(CharacterBase characterBase, CharacterData data)
        {
            character = characterBase;
            characterData = data;
            rb = characterBase.GetComponent<Rigidbody>();
            animatorController = characterBase.GetComponent<AnimatorController>();
            movementController = characterBase.GetComponent<MovementController>();
            movementController.Init(this);         
        }
    }
}