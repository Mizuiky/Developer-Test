using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Test.Event;

namespace Test.Shop
{
    public enum ItemType
    {
        Color,
        StackAmount
    }

    public class ShopItemBase : MonoBehaviour, IShopItem
    {
        [SerializeField] protected GameEventObject _onItemSold;
        [SerializeField] protected TextMeshProUGUI _itemName;
        [SerializeField] protected TextMeshProUGUI _priceText;
        [SerializeField] protected Button _priceButton;

        protected float _price;
        protected string _name;
        protected string _soldOut = "Sold";
        protected bool _hasSold;

        public float Price { get { return _price; } }

        public virtual void Init() 
        {
            _itemName.text = _name.ToString();
            _priceText.text = _price.ToString();
            _priceButton.enabled = true;
            _hasSold = false;
        }

        public virtual void SellItem() 
        {
            //particle
            //audio
            _priceText.text = _soldOut;
            _hasSold = true;
        }
        public virtual void CheckStoreItem() 
        {
            _onItemSold.Invoke(this);
        }

        public virtual void UseItem() { }
    }
}