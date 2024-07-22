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
        [SerializeField] protected TextMeshProUGUI _nameText;
        [SerializeField] protected TextMeshProUGUI _priceText;
        [SerializeField] protected Button _priceButton;

        protected float _price;
        protected string _itemName;
        protected string _soldOut = "Sold";
        protected bool _hasSold;

        public float Price { get { return _price; } }

        public void Start()
        {
            Init();    
        }

        public virtual void Init() 
        {
            _hasSold = false;
            _nameText.text = _itemName.ToString();
            _priceText.text = _price.ToString();
        }

        public virtual void SellItem() 
        {
            //particle
            //audio
            _hasSold = true;
        }
        public virtual void CheckStoreItem() 
        {
            _onItemSold.Invoke(this);
        }

        public virtual void UseItem() { }
    }
}