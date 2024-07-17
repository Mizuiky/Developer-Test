using UnityEngine;
using Test.Input;

namespace Test.Characters
{
    public class PlayerController : CharacterBase
    {
        private PlayerInputController _inputController;

        public override void OnLoad()
        {
            _inputController = GetComponent<PlayerInputController>();
            base.OnLoad();
        }

        public override void Init()
        {
            _inputController.Init();
        }      
    }
}