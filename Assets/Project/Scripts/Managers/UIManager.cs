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
    [Header("Item Description Box")]
    [SerializeField] private ItemDescriptionView itemDescriptionView;
    [SerializeField] private Button ItemDescriptionBoxButton;
    [Header("Item Quantity Box")]
    [SerializeField] private ItemQuantityView itemQuantityView;
    [Header("Money")]
    [SerializeField] private MoneyView moneyView;
    [Header("Confirmation Box")]
    [SerializeField] private ConfirmationBoxView confirmationBoxView;

    private EventService eventService;
    private GatherButtonEvent gatherButtonEvent;
    private InventoryController inventoryController;
    private ItemDescriptionController itemDescriptionController;
    private ItemQuantityController itemQuantityController;
    private MoneyController moneyController;
    private ConfirmationBoxController confirmationBoxController;
    public void SetEventService(EventService eventService) => this.eventService = eventService;
    private void Start()
    {
        inventoryView.gameObject.SetActive(false);
        gatherButton.gameObject.SetActive(false);
        shopView.gameObject.SetActive(false);
        itemDescriptionView.gameObject.SetActive(false);
        Initialize();
        InitializeButtons();
    }

    private void InitializeButtons()
    {
        inventoryButton.onClick.AddListener(SetActiveInventoryView);
        gatherButton.onClick.AddListener(gatherButtonEvent.GatherItem);
        shopButton.onClick.AddListener(SetActiveShopView);
        ItemDescriptionBoxButton.onClick.AddListener(SetActiveItemQuantityBox);
    }
    private void Initialize()
    {
        inventoryController = new InventoryController(inventoryScriptableObject, inventoryView, eventService);
        gatherButtonEvent = new GatherButtonEvent(itemScriptableObjectList, eventService, itemRarity);
        itemDescriptionController = new ItemDescriptionController(itemDescriptionView, eventService);
        itemQuantityController = new ItemQuantityController(itemQuantityView, eventService);
        moneyController = new MoneyController(moneyView, eventService);
        confirmationBoxController = new ConfirmationBoxController(confirmationBoxView, eventService);
    }
    private void SetActiveInventoryView() 
    { 
        inventoryView.gameObject.SetActive(true);
        gatherButton.gameObject.SetActive(true);
        shopView.gameObject.SetActive(false);
    }
    private void SetActiveShopView()
    {
        shopView.gameObject.SetActive(true);
        inventoryView.gameObject.SetActive(false);
        gatherButton.gameObject.SetActive(false);
    }
    private void SetActiveItemQuantityBox() => itemQuantityView.gameObject.SetActive(true);
}
