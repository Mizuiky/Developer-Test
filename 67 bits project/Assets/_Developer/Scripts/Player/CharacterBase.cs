using UnityEngine;

namespace Test.Characters
{
    public class CharacterBase : MonoBehaviour
    {
        [SerializeField] private CharacterComponents _components;
        [SerializeField] private CharacterData characterData;

        public void Start()
        {
            OnLoad();
            Init();
        }

        public virtual void OnLoad()
        {
            _components = new CharacterComponents(this, characterData);
        }

        public virtual void Init() { }
    }
}