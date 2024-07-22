using Test.Colors;
using UnityEngine;

namespace Test.Shop
{
    [CreateAssetMenu(menuName = "Data/Shop/ColorItem")]
    public class ColorItemData : ScriptableObject
    {
        public string itemName;
        public ColorDataType colordataType;
        public ItemType itemType;
        public int colorIndex;
        public float price;
    }
}