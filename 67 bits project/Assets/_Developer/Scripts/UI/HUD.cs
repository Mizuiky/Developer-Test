using UnityEngine;
using TMPro;
using Test.SOValue;

namespace Test.UI
{
    public class HUD : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _money;
        [SerializeField] private TextMeshProUGUI _charactersQtd;

        [SerializeField] private SoFloat _moneyValue;
        [SerializeField] private SoInt _characterQtdValue;

        public void Update()
        {
            _money.text = _moneyValue.value.ToString();
            _charactersQtd.text = _characterQtdValue.value.ToString();
        }
    }
}