public class MoneyController
{
    private MoneyView moneyView;
    private int currentMoney;
    private EventService eventService;
    public MoneyController(MoneyView moneyView, EventService eventService)
    {
        this.moneyView = moneyView;
        moneyView.SetMoneyController(this);
        currentMoney = 0;
        moneyView.UpdateMoney(currentMoney);
        this.eventService = eventService;
        eventService.AddMoney.AddListener(AddMoney);
        eventService.SubtractMoney.AddListener(SubtractMoney);
    }
    private void AddMoney(int amount)
    {
        currentMoney += amount;
        moneyView.UpdateMoney(currentMoney);
    }
    private void SubtractMoney(int amount)
    {
        if (currentMoney - amount >= 0)
        {
            currentMoney -= amount;
            moneyView.UpdateMoney(currentMoney);
        }
    }
    ~MoneyController()
    {
        eventService.AddMoney.RemoveListener(AddMoney);
        eventService.SubtractMoney.RemoveListener(SubtractMoney);
    }
}