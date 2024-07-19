using UnityEngine;
using Test.Movement;
using Test.Animation;

namespace Test.Characters
{
    public class CharacterComponents
    {
        public Rigidbody rb { get; private set; }
        public AnimationBase animationBase { get; private set; }
        public MovementController movementController { get; private set; }
        public CharacterBase character { get; private set; }

        public CharacterComponents(CharacterBase characterBase)
        {
            character = characterBase;
            rb = characterBase.GetComponent<Rigidbody>();
            animationBase = characterBase.GetComponentInChildren<AnimationBase>();
            movementController = characterBase.GetComponent<MovementController>();
            movementController.Init(this);         
        }
    }
}