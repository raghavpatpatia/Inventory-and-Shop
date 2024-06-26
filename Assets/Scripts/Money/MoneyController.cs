public class MoneyController
{
    private MoneyView moneyView;
    public int CurrentMoney { get; private set; }
    private EventService eventService;
    public MoneyController(MoneyView moneyView, EventService eventService)
    {
        this.moneyView = moneyView;
        moneyView.SetMoneyController(this);
        CurrentMoney = 0;
        moneyView.UpdateMoney(CurrentMoney);
        this.eventService = eventService;
    }
    public void AddMoney(int amount)
    {
        CurrentMoney += amount;
        moneyView.UpdateMoney(CurrentMoney);
    }
    public void SubtractMoney(int amount)
    {
        if (CurrentMoney - amount >= 0)
        {
            CurrentMoney -= amount;
            moneyView.UpdateMoney(CurrentMoney);
        }
        else
        {
            eventService.DisplayMessage.Invoke("Not enough money.");
        }
    }
}