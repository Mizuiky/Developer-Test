using UnityEngine;
using Test.Movement;
using Test.Animation;

namespace Test.Characters
{
    public class CharacterComponents
    {
        public Rigidbody rb { get; private set; }
        public AnimationController animatorController { get; private set; }
        public MovementController movementController { get; private set; }
        public CharacterBase character { get; private set; }
        public  CharacterData characterData { get; private set; }

        public CharacterComponents(CharacterBase characterBase, CharacterData data)
        {
            character = characterBase;
            characterData = data;
            rb = characterBase.GetComponent<Rigidbody>();
            animatorController = characterBase.GetComponent<AnimationController>();
            movementController = characterBase.GetComponent<MovementController>();
            movementController.Init(this);         
        }
    }
}