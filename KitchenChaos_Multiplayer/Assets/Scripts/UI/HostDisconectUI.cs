using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class HostDisconectUI : MonoBehaviour
{
    [SerializeField] private Button playAgainButton;

    private void Start() {
        NetworkManager.Singleton.OnClientDisconnectCallback += NetworManager_OnClientDisconnectCallback;

        Hide();
    }

    private void Awake() {
        playAgainButton.onClick.AddListener(() => {
            NetworkManager.Singleton.Shutdown();
            Loader.Load(Loader.Scene.MainMenuScene);
        });
    }

    private void NetworManager_OnClientDisconnectCallback(ulong clientId) {
        if (clientId == NetworkManager.ServerClientId) {
            // Server is shutting down
            Show();
        }
        
    }

    private void Show() {
        gameObject.SetActive(true);    
    }
    private void Hide() {
        gameObject.SetActive(false);    
    }
}
