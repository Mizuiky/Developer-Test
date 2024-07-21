using Test.SOValue;
using Test.Event;

namespace Test.Managers
{
    public class CurrencyManager
    {
        private SoFloat _money;
        private SoInt _characterAmount;
        private GameEventObject _onMoneyValueChanged;
        private GameEvent _onCharacterValueChanged;

        private int _maxStackHeight;

        public void Init(SoFloat money, SoInt chrAmount, GameEventObject moneyEvent, GameEvent characterEvent)
        {
            _money = money;
            _characterAmount = chrAmount;

            _money.value = 0f;
            _characterAmount.value = 0;

            _onMoneyValueChanged = moneyEvent;
            _onMoneyValueChanged.Subscribe(UpdateMoneyValue);

            _onCharacterValueChanged = characterEvent;
            _onCharacterValueChanged.Subscribe(UpdateCharacterAmount);
        }

        public void Reset()
        {
            _money.value = 0f;
            _characterAmount.value = 0;
        }

        public void UnsubscribeEvents()
        {
            _onMoneyValueChanged.Unsubscribe(UpdateMoneyValue);
            _onCharacterValueChanged.Unsubscribe(UpdateCharacterAmount);
        }

        public void UpdateMoneyValue(object value)
        {
            _money.value += (float)value;
        }

        public void UpdateCharacterAmount()
        {
            _characterAmount.value += 1;
        }
    }
}