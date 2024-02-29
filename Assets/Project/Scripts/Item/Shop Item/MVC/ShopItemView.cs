using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemView : MonoBehaviour
{
    [SerializeField] private Image ItemIcon;
    [SerializeField] private TextMeshProUGUI ItemName;
    [SerializeField] private Button BuyButton;
    private ShopItemController shopItemController;
    public void SetShopItemController(ShopItemController shopItemController) => this.shopItemController = shopItemController;
    public void SetItemIcon(Sprite itemIcon) => this.ItemIcon.sprite = itemIcon;
    public void SetItemName(string ItemName) => this.ItemName.text = ItemName;
    private void Start() => BuyButton.onClick.AddListener(shopItemController.OnShopItemClick);
}