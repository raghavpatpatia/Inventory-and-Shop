using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemView : MonoBehaviour
{
    [SerializeField] private Image itemIcon;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private Button buyButton;
    private ShopItemController shopItemController;
    public void SetShopItemController(ShopItemController shopItemController) => this.shopItemController = shopItemController;
    public void SetItemIcon(Sprite itemIcon) => this.itemIcon.sprite = itemIcon;
    public void SetItemName(string ItemName) => this.itemName.text = ItemName;
    private void Start() => buyButton.onClick.AddListener(shopItemController.OnShopItemClick);
}