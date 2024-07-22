using UnityEngine;
using TMPro;
using Test.SOValue;

namespace Test.Shop
{
    public class ShopController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _moneyText;
        [SerializeField] private SoFloat _playerMoney;

        private bool _isOpen;

        public void Init()
        {
            _moneyText.text = _playerMoney.value.ToString();
            _isOpen = false;
            gameObject.SetActive(false);
        }

        public void Open()
        {
            if (!_isOpen)
            {
                gameObject.SetActive(true);
                _isOpen = true;
            }
            else
            {
                gameObject.SetActive(false);
                _isOpen = false;
            }
        }

        public void Sell(ShopItemBase item)
        {
            if (_playerMoney.value == 0f || _playerMoney.value < item.Price) return;

            _playerMoney.value -= item.Price;
            _moneyText.text = _playerMoney.value.ToString();
            item.SellItem();
        }           
    }
}