using UnityEngine;
using System.Collections.Generic;

namespace Test.Color
{
    [CreateAssetMenu(menuName = "Data/Color")]
    public class ColorData : ScriptableObject
    {
        public List<ColorSet> _colors;
    }

    [System.Serializable]
    public class ColorSet
    {
        public Material color;
        public int colorIndex;
    }
}