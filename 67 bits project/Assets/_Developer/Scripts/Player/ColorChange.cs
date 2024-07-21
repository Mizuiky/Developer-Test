using System.Linq;
using UnityEngine;

namespace Test.Color
{
    public enum ColorDataType
    {
        Body,
        Shirt,
        Pants
    }

    public class ColorController : MonoBehaviour
    {
        [SerializeField] private SkinnedMeshRenderer _body;
        [SerializeField] private SkinnedMeshRenderer _shirt;
        [SerializeField] private SkinnedMeshRenderer _pants;

        [SerializeField] private ColorData _bodyColors;
        [SerializeField] private ColorData _shirtColors;
        [SerializeField] private ColorData _pantsColors;

        private SkinnedMeshRenderer _model;

        public void SetColor(ColorDataType type, ColorData data, int colorIndex)
        {
            _model = SetModel(type);
            if (_model == null) return;

            Material material = data._colors.FirstOrDefault(x => x.colorIndex == colorIndex).color;
            if (material == null) return;
            _body.material = material;
        }

        private SkinnedMeshRenderer SetModel(ColorDataType type)
        {
            _model = null;

            switch (type)
            {
                case ColorDataType.Body:
                    _model = _body;
                    break;
                case ColorDataType.Shirt:
                    _model = _shirt;
                    break;
                case ColorDataType.Pants:
                    _model = _pants;
                    break;
            }

            return _model;
        }
    }
}