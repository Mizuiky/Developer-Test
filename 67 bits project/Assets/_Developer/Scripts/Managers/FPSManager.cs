using UnityEngine;
using Test.SOValue;
using TMPro;
using System.Collections;
using Unity.IntegerTime;

namespace Test.Manager
{
    public class FPSManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _fpsText;
        [SerializeField] private Color _highFpsColor;
        [SerializeField] private Color _lowFpsColor;
        [SerializeField] private float _intervalValue;

        private float _fpsValue;
        private float _frameCount;
        private string _fpsFormatedText;
        private float _elapsedTime;
        private Color _currentFpsColor;

        public void Init()
        {
            Application.targetFrameRate = 60;
            StartCoroutine(FpsCoroutine());
        }

        public void Update()
        {
            _frameCount++;
            _elapsedTime += Time.deltaTime;
        }
        private IEnumerator FpsCoroutine()
        {
            //game is running
            while(true)
            {
                yield return new WaitForSeconds(_intervalValue);
                CalculateFPSValue();
               
            }
        }

        private void CalculateFPSValue()
        {
            _fpsValue = _frameCount / _elapsedTime;
            _fpsFormatedText = string.Format("FPS: {0.0}", _fpsValue);

            _currentFpsColor = _fpsValue >= 30f ? _highFpsColor : _lowFpsColor;

            if (_fpsText.color != _currentFpsColor)
            {
                _fpsText.text = _fpsFormatedText;
                _fpsText.color = _currentFpsColor;
            }

            _frameCount = 0;
            _elapsedTime = 0;
        }
    }
}