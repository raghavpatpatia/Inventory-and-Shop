using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Main Menu")]
    [SerializeField] private Button inventoryButton;
    [SerializeField] private Button shopButton;
    [SerializeField] private Button quitButton;
    [Header("Gather Item")]
    [SerializeField] private Button gatherButton;
    [SerializeField] private ItemRarity itemRarity;
    [Header("Item")]
    [SerializeField] private ItemSOList itemScriptableObjectList;
    [Header("Inventory")]
    [SerializeField] private InventoryView inventoryView;
    [SerializeField] private InventorySO inventoryScriptableObject;
    [Header("Shop")]
    [SerializeField] private ShopView shopView;

    private EventService eventService;
    private GatherButtonEvent gatherButtonEvent;
    private InventoryController inventoryController;
    public void SetEventService(EventService eventService) => this.eventService = eventService;
    private void Start()
    {
        SetActiveInventoryView(false);
        SetActiveShopView(false);
        Initialize();
        InitializeButtons();
    }

    private void InitializeButtons()
    {
        inventoryButton.onClick.AddListener(() => SetActiveInventoryView(true));
        gatherButton.onClick.AddListener(gatherButtonEvent.GatherItem);
        shopButton.onClick.AddListener(() => SetActiveShopView(true));
    }
    private void Initialize()
    {
        inventoryController = new InventoryController(inventoryScriptableObject, inventoryView, eventService);
        gatherButtonEvent = new GatherButtonEvent(itemScriptableObjectList, eventService, itemRarity);
    }
    private void SetActiveInventoryView(bool status) 
    { 
        inventoryView.gameObject.SetActive(status);
        gatherButton.gameObject.SetActive(status);
    }
    private void SetActiveShopView(bool status) => shopView.gameObject.SetActive(status);
}
