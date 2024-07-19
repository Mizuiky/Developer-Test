using UnityEngine;

namespace Test.Characters
{
    public class PlayerController : PlayerCharacter
    {
        [SerializeField] private Transform _stackParent;
     
        private Transform _stackPosition;
        private Transform _newPivot;
        private int _stackCount = 0;
        private float _stackHeight;
        public Transform StackPosition { get { return _newPivot; } }     
        public Transform StackParent { get { return _stackParent; } }
    
        public override void Init()
        {
            _stackCount = 0;
            _stackPosition = _stackParent;
            _newPivot = _stackPosition;
            base.Init();
        }

        public void SetStackPosition()
        {
            if(_stackCount == 0)
                _stackHeight = _stackParent.localPosition.y;
            else
                _stackHeight = _stackParent.localPosition.y * _stackCount;

            _newPivot.position = new Vector3(_stackParent.position.x, _stackHeight, _stackParent.position.z);
            _stackCount++;
        }
    }
}