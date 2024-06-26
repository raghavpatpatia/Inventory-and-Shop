using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmationBoxView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI confirmationText;
    [SerializeField] private Button confirmationButton;
    private ConfirmationBoxController confirmationBoxController;
    public void SetConfirmationBoxController(ConfirmationBoxController confirmationBoxController) => this.confirmationBoxController = confirmationBoxController;
    public void SetConfirmationBoxText(string text) => confirmationText.text = text;
    private void Start()
    {
        confirmationButton.onClick.AddListener(confirmationBoxController.OnConfirmationButtonClick);
    }
}