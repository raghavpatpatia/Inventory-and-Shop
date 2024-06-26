public class ConfirmationBoxController
{
    private ConfirmationBoxView confirmationBoxView;
    private EventService eventService;
    public ConfirmationBoxController(ConfirmationBoxView confirmationBoxView, EventService eventService)
    {
        this.confirmationBoxView = confirmationBoxView;
        confirmationBoxView.SetConfirmationBoxController(this);
        this.eventService = eventService;
        eventService.ConfirmationBoxMessage.AddListener(SetConfirmationBoxText);
    }

    private void SetConfirmationBoxText(string message)
    {
        confirmationBoxView.gameObject.SetActive(true);
        confirmationBoxView.SetConfirmationBoxText(message);
    }
    public void OnConfirmationButtonClick()
    {
        eventService.OnConfirmButtonClick.Invoke();
    }
    ~ConfirmationBoxController()
    {
        eventService.ConfirmationBoxMessage.RemoveListener(SetConfirmationBoxText);
    }
}