using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIManager uiManager;
    private EventService eventService;

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        eventService = new EventService();
        uiManager.SetEventService(eventService);
    }
}