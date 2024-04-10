using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemQuantityView : MonoBehaviour
{
    [SerializeField] private Image itemIcon;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemQuantity;
    [SerializeField] private Button minusButton;
    [SerializeField] private Button plusButton;
    [SerializeField] private TextMeshProUGUI confirmationButtonText;
    [SerializeField] private Button confirmationBoxButton;
    private ItemQuantityController itemQuantityController;
    public void SetItemQuantityController(ItemQuantityController itemQuantityController) => this.itemQuantityController = itemQuantityController;
    private void Start()
    {
        confirmationBoxButton.onClick.AddListener(itemQuantityController.OnConfirmationBoxButtonClick);
        minusButton.onClick.AddListener(itemQuantityController.OnMinusButtonClicked);
        plusButton.onClick.AddListener(itemQuantityController.OnPlusButtonClick);
    }
    public void SetItemIcon(Sprite itemIcon) => this.itemIcon.sprite = itemIcon;
    public void SetItemName(string itemName) => this.itemName.text = itemName;
    public void SetItemQuantity(int itemQuantity) => this.itemQuantity.text = itemQuantity.ToString();
    public void SetConfirmationButtonText(string text) => this.confirmationButtonText.text = text;
}