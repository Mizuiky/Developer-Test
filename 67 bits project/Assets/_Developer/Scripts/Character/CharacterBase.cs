using UnityEngine;

namespace Test.Characters
{
    public class CharacterBase : MonoBehaviour
    {
        [SerializeField] private CharacterData characterData;
        public CharacterComponents _components;

        public void Awake()
        {
            OnLoad();
        }

        public void Start()
        {
           
            Init();
        }

        public virtual void OnLoad()
        {
            _components = new CharacterComponents(this, characterData);
        }

        public virtual void Init() { }

        public virtual void Reset() { }
    }
}