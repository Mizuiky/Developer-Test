using Test.Event;
using UnityEngine;
using Test.Shop;

namespace Test.UI
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private HUD _hud;
        [SerializeField] private ShopController _shopController;
        [SerializeField] private GameEventObject _onItemSold;

        public void OnEnable()
        {
            _onItemSold.Subscribe(ShopItemCallBack);
        }

        public void Start()
        {
            Init();
        }

        public void Init()
        {
            _shopController.Init();
        }

        #region Shop
        private void ShopItemCallBack(object args)
        {
            _shopController.Sell((ShopItemBase)args);
        }

        public void OpenShop(bool canOpen)
        {
            _shopController.Open(canOpen);   
        }
        #endregion

        public void OnDisable()
        {
            _onItemSold.Unsubscribe(ShopItemCallBack);
        }
    }
}