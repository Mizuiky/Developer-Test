using UnityEngine;

namespace Test.Characters
{
    [CreateAssetMenu(menuName = "Data/Player")]
    public class PlayerData : ScriptableObject
    {
        public string characterName;
        public float maxSpeed;
        public float acceleration;
        public float deaceleration;
        public float rotationSmoothTime;
        public int maxStackAmount;
    }
}