using System.Collections;
using UnityEngine;

public class MessageBoxController
{
    private MessageBoxView messageBoxView;
    private EventService eventService;
    private Coroutine showMessageCoroutine;

    public MessageBoxController(MessageBoxView messageBoxView, EventService eventService)
    {
        this.messageBoxView = messageBoxView;
        messageBoxView.SetMessageBoxController(this);
        this.eventService = eventService;
        eventService.DisplayMessage.AddListener(SetMessage);
    }

    private void SetMessage(string message)
    {
        messageBoxView.gameObject.SetActive(true);
        if (showMessageCoroutine != null)
        {
            messageBoxView.StopCoroutine(showMessageCoroutine);
        }
        showMessageCoroutine = messageBoxView.StartCoroutine(ShowMessage(message));
    }

    private IEnumerator ShowMessage(string message)
    {
        messageBoxView.ChangeMessage(message);
        yield return new WaitForSeconds(10);
        messageBoxView.gameObject.SetActive(false);
    }
    ~MessageBoxController() => eventService.DisplayMessage.RemoveListener(SetMessage);
}
