using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Sound")]
    [SerializeField] private AudioSource backgroundMusic;
    [SerializeField] private AudioSource soundEffect;
    [SerializeField] private SoundType[] soundTypes;
    [Header("UI Manager")]
    [SerializeField] private UIManager uiManager;
    private EventService eventService;
    private SoundController soundController;
    private void Start()
    {
        Initialize();
        soundController.PlayBGMusic(Sounds.BGMUSIC);
    }

    private void Initialize()
    {
        eventService = new EventService();
        soundController = new SoundController(soundEffect, backgroundMusic, soundTypes);
        uiManager.Init(eventService, soundController);
    }
}