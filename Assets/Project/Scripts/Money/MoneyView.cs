using TMPro;
using UnityEngine;

public class MoneyView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyText;
    private MoneyController moneyController;
    public void SetMoneyController(MoneyController moneyController) => this.moneyController = moneyController;
    public void UpdateMoney(int amount) => moneyText.text = amount.ToString();
}