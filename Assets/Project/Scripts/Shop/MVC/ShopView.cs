using UnityEngine;
using UnityEngine.UI;

public class ShopView : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button MaterialButton;
    [SerializeField] private Button ArmorButton;
    [SerializeField] private Button WeaponButton;
    [SerializeField] private Button ConsumableButton;
    [SerializeField] private Button TreasureButton;
    [Header("Panels")]
    [SerializeField] private GameObject Material;
    [SerializeField] private GameObject Armor;
    [SerializeField] private GameObject Weapon;
    [SerializeField] private GameObject Consumable;
    [SerializeField] private GameObject Treasure;
    [Header("Content Area")]
    [SerializeField] private Transform MaterialContentTransform;
    [SerializeField] private Transform ArmorContentTransform;
    [SerializeField] private Transform WeaponContentTransform;
    [SerializeField] private Transform ConsumableContentTransform;
    [SerializeField] private Transform TreasureContentTransform;
    private ShopController shopController;
    public void SetShopController(ShopController shopController) => this.shopController = shopController;
    private void OnEnable()
    {
        MaterialButton.onClick.AddListener(OnMaterialButtonClick);
        ArmorButton.onClick.AddListener(OnArmorButtonClick);
        WeaponButton.onClick.AddListener(OnWeaponButtonClick);
        ConsumableButton.onClick.AddListener(OnConsumableButtonClick);
        TreasureButton.onClick.AddListener(OnTreasureButtonClick);
    }
    private void Start() => shopController.AddItemToShop(MaterialContentTransform, ArmorContentTransform, WeaponContentTransform, ConsumableContentTransform, TreasureContentTransform);
    private void OnMaterialButtonClick()
    {
        Material.SetActive(true);
        Armor.SetActive(false);
        Weapon.SetActive(false);
        Consumable.SetActive(false);
        Treasure.SetActive(false);
    }
    private void OnArmorButtonClick()
    {
        Material.SetActive(false);
        Armor.SetActive(true);
        Weapon.SetActive(false);
        Consumable.SetActive(false);
        Treasure.SetActive(false);
    }
    private void OnWeaponButtonClick()
    {
        Material.SetActive(false);
        Armor.SetActive(false);
        Weapon.SetActive(true);
        Consumable.SetActive(false);
        Treasure.SetActive(false);
    }
    private void OnConsumableButtonClick()
    {
        Material.SetActive(false);
        Armor.SetActive(false);
        Weapon.SetActive(false);
        Consumable.SetActive(true);
        Treasure.SetActive(false);
    }
    private void OnTreasureButtonClick()
    {
        Material.SetActive(false);
        Armor.SetActive(false);
        Weapon.SetActive(false);
        Consumable.SetActive(false);
        Treasure.SetActive(true);
    }
}