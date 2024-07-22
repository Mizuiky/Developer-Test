using Test.Event;
using UnityEngine;

namespace Test.Shop
{
    public class ColorItem : ShopItemBase
    {
        [SerializeField] private ColorItemData _colorItemData;
        [SerializeField] private GameEventObject _onColorUse;

        public ColorItemData ColorData { get { return _colorItemData; } }

        public override void Init()
        {
            _price = _colorItemData.price;
            _itemName = _colorItemData.itemName;
            base.Init();      
        }

        public override void SellItem()
        {
            base.SellItem();
            _soldOut = "Use";
            _priceText.text = _soldOut;
        }   
        
        public override void CheckStoreItem()
        {
            if (_hasSold)
            {
                UseItem();
                return;
            }
            base.CheckStoreItem();
        }

        public override void UseItem()
        {
            base.UseItem();
            _onColorUse.Invoke(_colorItemData);
        }
    }
}