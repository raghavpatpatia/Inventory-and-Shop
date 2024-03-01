public class MoneyController
{
    private MoneyView moneyView;
    public int currentMoney { get; private set; }
    private EventService eventService;
    public MoneyController(MoneyView moneyView, EventService eventService)
    {
        this.moneyView = moneyView;
        moneyView.SetMoneyController(this);
        currentMoney = 0;
        moneyView.UpdateMoney(currentMoney);
        this.eventService = eventService;
    }
    public void AddMoney(int amount)
    {
        currentMoney += amount;
        moneyView.UpdateMoney(currentMoney);
    }
    public void SubtractMoney(int amount)
    {
        if (currentMoney - amount >= 0)
        {
            currentMoney -= amount;
            moneyView.UpdateMoney(currentMoney);
        }
        else
        {
            eventService.DisplayMessage.Invoke("Not enough money.");
        }
    }
}