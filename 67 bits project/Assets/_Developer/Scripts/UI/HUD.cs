using UnityEngine;
using TMPro;
using Test.SOValue;

namespace Test.UI
{
    public class HUD : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _money;
        [SerializeField] private TextMeshProUGUI _currentCharacterAmount;
        [SerializeField] private TextMeshProUGUI _currentMaxCharacterAmount;

        [SerializeField] private SoFloat _moneyValue;
        [SerializeField] private SoInt _currentCharacterQtd;
        [SerializeField] private SoInt _maxCharacterQtd;
       
        public void Update()
        {
            _money.text = _moneyValue.value.ToString();
            _currentCharacterAmount.text = _currentCharacterQtd.value.ToString();
            _currentMaxCharacterAmount.text = _maxCharacterQtd.value.ToString();
        }
    }
}