using Unity.Netcode;
using UnityEngine;

public class MenuManager : MonoBehaviour {
    [SerializeField] private GameObject menuUI;
    [SerializeField] private GameObject lobbyUI;

    public void StartHost() {
        SwitchUI();
        NetworkManager.Singleton.StartHost();
    }

    public void StartClient() {
        SwitchUI();
        NetworkManager.Singleton.StartClient();
    }

    public void Options() {
        Debug.Log("Options must be added soon");
    }

    public void Exit() {
        Application.Quit();
    }

    public void SwitchUI() {
        menuUI.SetActive(!menuUI.activeSelf);
        lobbyUI.SetActive(!lobbyUI.activeSelf);
    }
}