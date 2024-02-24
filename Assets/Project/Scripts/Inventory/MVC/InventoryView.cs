using TMPro;
using UnityEngine;

public class InventoryView : MonoBehaviour
{
    [SerializeField] public GameObject contentArea;
    [SerializeField] private TextMeshProUGUI inventoryWeight;
    private InventoryController inventoryController;
    private void Start()
    {
        SetInventoryWeightText();
    }
    public void SetInventoryController(InventoryController inventoryController) => this.inventoryController = inventoryController;
    public void SetInventoryWeightText() => inventoryWeight.text = string.Format("{0} / {1} KG", inventoryController.GetInventoryWeight(), inventoryController.GetInventoryMaxWeight());
}