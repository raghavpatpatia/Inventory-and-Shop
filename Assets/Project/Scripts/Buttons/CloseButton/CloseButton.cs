using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class CloseButton : MonoBehaviour
{
    [SerializeField] private Button closeButton;
    [SerializeField] private List<GameObject> deactivateGameObjects;
    private void Start()
    {
        closeButton.onClick.AddListener(OnCloseButtonClick);
    }
    private void OnCloseButtonClick()
    {
        if (deactivateGameObjects != null)
        {
            foreach (GameObject activeGameObject in deactivateGameObjects)
            {
                activeGameObject.SetActive(false);
            }
        }
    }
}