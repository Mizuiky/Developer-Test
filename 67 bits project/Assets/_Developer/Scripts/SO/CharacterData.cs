using UnityEngine;

namespace Test.Characters
{
    [CreateAssetMenu(menuName = "Data/Character")]
    public class CharacterData : ScriptableObject
    {
        public string characterName;
        public float maxSpeed;
    }
}