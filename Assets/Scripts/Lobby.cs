using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Lobby : NetworkBehaviour {
    [SerializeField] private TextMeshProUGUI[] playerNickTexts;
    [SerializeField] private Button startGameButton;

    private NetworkList<LobbyPlayer> playerList;
    
    public override void OnNetworkSpawn() {
        if(IsClient) {
            playerList.OnListChanged += UpdateLobbyUI;
        }

        if(IsServer) {
            NetworkManager.Singleton.OnClientConnectedCallback += HandleClientConnected;
            NetworkManager.Singleton.OnClientDisconnectCallback += HandleClientDisconnect;

            foreach(var client in NetworkManager.Singleton.ConnectedClientsList) {
                HandleClientConnected(client.ClientId);
            }
            
            startGameButton.gameObject.SetActive(true);
        }
    }

    private void HandleClientConnected(ulong clientId) {
        playerList.Add(new LobbyPlayer(clientId, System.DateTime.Now.Second.ToString()));
    }

    private void HandleClientDisconnect(ulong clientId) {
        for(int i = 0; i < playerList.Count; i++) {
            if(clientId == playerList[i].id) {
                playerList.RemoveAt(i);
                return;
            }
        }
    }

    public void StartGame() {
        NetworkManager.Singleton.SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }
    
    public void Disconnect() {
        if(IsClient) {
            NetworkManager.Singleton.DisconnectClient(NetworkManager.Singleton.LocalClientId);
        }
        if(IsServer) {
            NetworkManager.Singleton.Shutdown();
        }
        FindObjectOfType<MenuManager>().SwitchUI();
    }

    private void UpdateLobbyUI(NetworkListEvent<LobbyPlayer> listEvent) {
        for(int i = 0; i < playerList.Count; i++) {
            playerNickTexts[i].text = playerList[i].name.ToString();
        }
    }
}