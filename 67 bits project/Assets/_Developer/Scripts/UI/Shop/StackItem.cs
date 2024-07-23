using UnityEngine;
using Test.Event;
using TMPro;
using Test.SOValue;

namespace Test.Shop
{
    public class StackItem : ShopItemBase
    {
        [SerializeField] private StackItemData _stackItemData;
        [SerializeField] private SoInt _maxCharacterAmount;
        [SerializeField] protected TextMeshProUGUI _nextAmountText;
        private int _nextStackAmountIndex;
        private int _currentStackAmountIndex;
        public StackItemData StackData { get { return _stackItemData; } }

        public override void Init()
        {
            _price = _stackItemData.initialPriceValue;
            _itemName = _stackItemData.itemName;

            _currentStackAmountIndex = 0;
            _stackItemData.currentMaxStackAmount = _stackItemData.stackAmount[_currentStackAmountIndex];

            _nextStackAmountIndex = 1;       
            _nextAmountText.text = $"{_stackItemData.stackAmount[_nextStackAmountIndex]}+";
            base.Init();
        }

        public override void SellItem()
        {
            //particle
            //audio
            _price += _stackItemData.priceAmountToIncrease;
            _priceText.text = _price.ToString();
            _nextStackAmountIndex++;
            _nextAmountText.text = $"{_stackItemData.stackAmount[_nextStackAmountIndex]}+";
            UseItem();
        }

        public override void CheckStoreItem()
        {
            base.CheckStoreItem();
        }

        public override void UseItem()
        {
            _currentStackAmountIndex++;
            _stackItemData.currentMaxStackAmount = _stackItemData.stackAmount[_currentStackAmountIndex];
            _maxCharacterAmount.value = _stackItemData.currentMaxStackAmount;
        }
    }
}