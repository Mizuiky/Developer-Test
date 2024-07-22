using UnityEngine;
using Test.SOValue;
using TMPro;

namespace Test.Manager
{
    public class FPSManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _fpsText;
        [SerializeField] private Color _highFpsColor;
        [SerializeField] private Color _lowFpsColor;

        private float _fpsValue;
        private string _fpsFormatedText;
        private float _deltaTime;

        public void Init()
        {
            Application.targetFrameRate = 60;
        }

        public void Update()
        {
            CalculateFPSValue();
        }

        private void CalculateFPSValue()
        {
            _deltaTime += (Time.deltaTime - _deltaTime) * 0.1f;
            _fpsValue = 1.0f / _deltaTime;
            _fpsFormatedText = string.Format("FPS: {0:0.}", _fpsValue);

            if(_fpsValue >= 30f)
                _fpsText.color = _highFpsColor;
            else
                _fpsText.color = _lowFpsColor;

            _fpsText.text = _fpsFormatedText;
        }
    }
}