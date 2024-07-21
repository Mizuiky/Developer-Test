using UnityEngine;
using TMPro;

namespace Test.Shop
{
    public class ShopController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _playerMoney;
        private float _money;

        public void Init()
        {
            _money = 0f;
            _playerMoney.text = _money.ToString();
            Open(false);
        }

        public void Open(bool open)
        {
            gameObject.SetActive(open);
        }

        public void Sell(ShopItemBase item)
        {
            if (_money == 0 || _money < item.Price) return;
            _money -= item.Price;
            item.SellItem();
        }           
    }
}