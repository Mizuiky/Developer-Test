using UnityEngine;
using Test.Event;

namespace Test.Shop
{
    public class StackItem : ShopItemBase
    {
        [SerializeField] private StackItemData _stackItemData;
        [SerializeField] private GameEventObject _onChangeStackAmount;

        public StackItemData StackData { get { return _stackItemData; } }

        public override void Init()
        {
            _price = _stackItemData.price;
            _name = _stackItemData.name;
            base.Init();
        }

        public override void SellItem()
        {
            base.SellItem();
            _soldOut = "Sold";
            _priceButton.enabled = false;
            UseItem();
        }

        public override void CheckStoreItem()
        {
            if (_hasSold) return;
            base.CheckStoreItem();
        }

        public override void UseItem()
        {
            _onChangeStackAmount.Invoke(_stackItemData);
        }
    }
}