using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class GameManager : NetworkBehaviour {
    [SerializeField] private GameObject playerPrefab;
    //private List<PlayerManager> players;

    private void Start() {
        if(!IsServer) {
            return;
        }

        foreach(var client in NetworkManager.Singleton.ConnectedClientsList) {
            SpawnPlayerServerRpc(client.ClientId);
        }
    }
    
    [ServerRpc(RequireOwnership = false)]
    private void SpawnPlayerServerRpc(ulong clientId) {
        GameObject player = Instantiate(playerPrefab);
        NetworkObject playerNetwork = player.GetComponent<NetworkObject>();
        
        playerNetwork.SpawnAsPlayerObject(clientId);
    }
}
