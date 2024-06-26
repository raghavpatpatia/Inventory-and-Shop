using UnityEngine;
using UnityEngine.UI;

public class ShopView : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button materialButton;
    [SerializeField] private Button armorButton;
    [SerializeField] private Button weaponButton;
    [SerializeField] private Button consumableButton;
    [SerializeField] private Button treasureButton;
    [Header("Panels")]
    [SerializeField] private GameObject material;
    [SerializeField] private GameObject armor;
    [SerializeField] private GameObject weapon;
    [SerializeField] private GameObject consumable;
    [SerializeField] private GameObject treasure;
    [Header("Content Area")]
    [SerializeField] private Transform materialContentTransform;
    [SerializeField] private Transform armorContentTransform;
    [SerializeField] private Transform weaponContentTransform;
    [SerializeField] private Transform consumableContentTransform;
    [SerializeField] private Transform treasureContentTransform;
    private ShopController shopController;
    public void SetShopController(ShopController shopController) => this.shopController = shopController;
    private void OnEnable()
    {
        materialButton.onClick.AddListener(OnMaterialButtonClick);
        armorButton.onClick.AddListener(OnArmorButtonClick);
        weaponButton.onClick.AddListener(OnWeaponButtonClick);
        consumableButton.onClick.AddListener(OnConsumableButtonClick);
        treasureButton.onClick.AddListener(OnTreasureButtonClick);
    }
    private void Start() => shopController.AddItemToShop(materialContentTransform, armorContentTransform, weaponContentTransform, consumableContentTransform, treasureContentTransform);
    private void OnMaterialButtonClick()
    {
        material.SetActive(true);
        armor.SetActive(false);
        weapon.SetActive(false);
        consumable.SetActive(false);
        treasure.SetActive(false);
    }
    private void OnArmorButtonClick()
    {
        material.SetActive(false);
        armor.SetActive(true);
        weapon.SetActive(false);
        consumable.SetActive(false);
        treasure.SetActive(false);
    }
    private void OnWeaponButtonClick()
    {
        material.SetActive(false);
        armor.SetActive(false);
        weapon.SetActive(true);
        consumable.SetActive(false);
        treasure.SetActive(false);
    }
    private void OnConsumableButtonClick()
    {
        material.SetActive(false);
        armor.SetActive(false);
        weapon.SetActive(false);
        consumable.SetActive(true);
        treasure.SetActive(false);
    }
    private void OnTreasureButtonClick()
    {
        material.SetActive(false);
        armor.SetActive(false);
        weapon.SetActive(false);
        consumable.SetActive(false);
        treasure.SetActive(true);
    }

    private void OnDisable()
    {
        materialButton.onClick.RemoveListener(OnMaterialButtonClick);
        armorButton.onClick.RemoveListener(OnArmorButtonClick);
        weaponButton.onClick.RemoveListener(OnWeaponButtonClick);
        consumableButton.onClick.RemoveListener(OnConsumableButtonClick);
        treasureButton.onClick.RemoveListener(OnTreasureButtonClick);
    }
}