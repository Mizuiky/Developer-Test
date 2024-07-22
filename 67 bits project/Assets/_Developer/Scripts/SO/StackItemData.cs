using NUnit.Framework;
using UnityEngine;

namespace Test.Shop
{
    [CreateAssetMenu(menuName = "Data/Shop/StackItem")]
    public class StackItemData : ScriptableObject
    {
        public string itemName;
        public int currentMaxStackAmount;
        public float initialPriceValue;
        public float priceAmountToIncrease;
        public int[] stackAmount;
    }
}