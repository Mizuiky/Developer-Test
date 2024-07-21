using UnityEngine;

namespace Test.Characters
{
    [CreateAssetMenu(menuName = "Data/SimpleCharacter")]
    public class SimpleCharacterData : ScriptableObject
    {
        [Header("Time do move to player stack pivot")]
        public float timeToMove;

        [Header("Character value to be sold")]
        public float characterValue;

        [Header("Values to Manage Inertia")]

        [Space(8)]

        [Header("Minimum and maximum X rotation to be aplied to the character body")]
        [Space(5)]
        public float minXrotation;
        public float maxXrotation;

        [Header("Minimum and maximum Y rotation to be aplied to the character body")]
        [Space(5)]
        public float minYrotation;
        public float maxYrotation;

        [Header("Minimum and maximum Z rotation to be aplied to the character body")]
        [Space(5)]
        public float minZrotation;
        public float maxZrotation;

        [Header("X and Z side balance to be aplied to the character body")]
        [Space(5)]
        public float xSideBalance;
        public float ZSideBalance;
    }
}