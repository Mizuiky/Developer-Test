using System.Linq;
using UnityEngine;
using Test.Shop;

namespace Test.Colors
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

        public void SetBodyColor(ColorItemData data)
        {
            _model = GetModel(data.colordataType);
            if (_model == null) return;

            Material material = _bodyColors._colors.FirstOrDefault(x => x.colorIndex == data.colorIndex).color;
            if (material == null) return;
            _body.material = material;
        }

        private SkinnedMeshRenderer GetModel(ColorDataType type)
        {
            switch (type)
            {
                case ColorDataType.Body:
                    return _body;
                case ColorDataType.Shirt:
                    return _shirt;
                case ColorDataType.Pants:
                    return _pants;
            }

            return null;
        }
    }
}