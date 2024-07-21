using UnityEngine;
namespace Test.Shop
{
    [CreateAssetMenu(menuName = "Data/Shop/StackItem")]
    public class StackItemData : ScriptableObject
    {
        public string itemName;
        public int stackAmount;
        public float price;
    }
}