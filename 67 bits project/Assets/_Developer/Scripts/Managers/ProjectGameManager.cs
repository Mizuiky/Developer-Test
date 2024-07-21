using Test.Event;
using Test.Managers;
using Test.SOValue;
using UnityEngine;

public class ProjectGameManager: MonoBehaviour
{
    #region Currency Manager
    [SerializeField] private CurrencyManager _currencyManager;
    [SerializeField] private SoFloat _money;
    [SerializeField] private SoInt _charactersAmount;
    [SerializeField] private GameEventObject _moneyEvent;
    [SerializeField] private GameEvent _characterAmountEvent;
    #endregion

    public void Start()
    {
        Init();
    }

    private void Init()
    {
        _currencyManager = new CurrencyManager();
        _currencyManager.Init(_money, _charactersAmount, _moneyEvent, _characterAmountEvent);
    }

    private void OnDisable()
    {
        _currencyManager.UnsubscribeEvents();
    }
}
