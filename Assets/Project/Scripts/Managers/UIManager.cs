using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Main Menu")]
    [SerializeField] private Button inventoryButton;
    [SerializeField] private Button gatherButton;
    [SerializeField] private Button shopButton;
    [SerializeField] private Button quitButton;
    [Header("Item")]
    [SerializeField] private ItemSOList itemScriptableObjectList;
    [Header("Inventory")]
    [SerializeField] private InventoryView inventoryView;
    [SerializeField] private InventorySO inventoryScriptableObject;
    [Header("Shop")]
    [SerializeField] private ShopView shopView;

    private EventService eventService;
    public void SetEventService(EventService eventService) => this.eventService = eventService;
    private void Start()
    {
        SetActiveInventoryView(false);
        SetActiveShopView(false);
        InitializeButtons();
    }

    private void InitializeButtons()
    {
        inventoryButton.onClick.AddListener(() => SetActiveInventoryView(true));
        shopButton.onClick.AddListener(() => SetActiveShopView(true));
    }

    private void SetActiveInventoryView(bool status) 
    { 
        inventoryView.gameObject.SetActive(status);
        gatherButton.gameObject.SetActive(status);
    }
    private void SetActiveShopView(bool status) => shopView.gameObject.SetActive(status);
}
