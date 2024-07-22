using Test.Event;
using UnityEngine;
using Test.Shop;
using Test.Manager;

namespace Test.UI
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private HUD _hud;
        [SerializeField] private FPSManager _fpsManager;
        [SerializeField] private ShopController _shopController;
        [SerializeField] private GameEventObject _onItemSold;
        [SerializeField] private GameEventObject _onUIOpened;

        [SerializeField] private PauseMenu _pauseMenu;

        public void OnEnable()
        {
            _onItemSold.Subscribe(ShopItemCallBack);
            _onUIOpened.Subscribe(OpenUI);
        }

        public void Start()
        {
            Init();
        }

        public void Init()
        {
            _shopController.Init();
            _pauseMenu.Init();
            _fpsManager.Init();
        }

        #region Shop
        private void ShopItemCallBack(object[] args)
        {
            _shopController.Sell((ShopItemBase)args[0]);
        }

        private void OpenUI(object[] args)
        {
            if ((int)args[0] == 0)
                _shopController.Open();

            else if ((int)args[0] == 1)
                _pauseMenu.Open();
        }

        #endregion

        public void OnDisable()
        {
            _onItemSold.Unsubscribe(ShopItemCallBack);
            _onUIOpened.Unsubscribe(OpenUI);
        }
    }
}