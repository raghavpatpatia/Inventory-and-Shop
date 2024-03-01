using TMPro;
using UnityEngine;
public class MessageBoxView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI message;
    private MessageBoxController messageBoxController;
    public void SetMessageBoxController(MessageBoxController messageBoxController) => this.messageBoxController = messageBoxController;
    public void ChangeMessage(string message) => this.message.text = message;
}