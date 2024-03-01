using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Sound")]
    [SerializeField] private AudioSource BackgroundMusic;
    [SerializeField] private AudioSource SoundEffect;
    [SerializeField] private SoundType[] soundTypes;
    [Header("UI Manager")]
    [SerializeField] private UIManager uiManager;
    private EventService eventService;
    private SoundController soundController;
    private void Start()
    {
        Initialize();
        soundController.PlayBGMusic(Sounds.BGMusic);
    }

    private void Initialize()
    {
        eventService = new EventService();
        soundController = new SoundController(SoundEffect, BackgroundMusic, soundTypes);
        uiManager.Init(eventService, soundController);
    }
}