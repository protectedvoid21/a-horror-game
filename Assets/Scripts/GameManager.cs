using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class GameManager : NetworkBehaviour {
    [SerializeField] private GameObject survivorPrefab;
    [SerializeField] private GameObject attackerPrefab;
    [SerializeField] private Transform spawnTransform;

    private ulong attackerId; 
    
    private void Start() {
        if(!IsServer) {
            return;
        }

        attackerId = GetAttackerClientId();
        foreach(var client in NetworkManager.Singleton.ConnectedClientsList) {
            SpawnPlayerServerRpc(client.ClientId);
        }
    }

    private ulong GetAttackerClientId() {
        int randomizedIndex = Random.Range(0, NetworkManager.Singleton.ConnectedClientsList.Count);

        return NetworkManager.Singleton.ConnectedClientsList[randomizedIndex].ClientId;
    }
    
    [ServerRpc(RequireOwnership = false)]
    private void SpawnPlayerServerRpc(ulong clientId) {
        GameObject prefabToSpawn = survivorPrefab;
        if(clientId == attackerId) {
            prefabToSpawn = attackerPrefab;
        }
        
        GameObject player = Instantiate(prefabToSpawn, spawnTransform.position, Quaternion.identity);
        player.GetComponent<NetworkObject>().SpawnAsPlayerObject(clientId);
    }
}
