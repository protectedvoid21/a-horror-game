using Unity.Netcode;
using UnityEngine;

public class PlayerAttacker : NetworkBehaviour {
    [SerializeField] private float detectDistance = 10f;
    
    private PlayerSurvivor[] playerSurvivors;

    private void Start() {
        if(!IsLocalPlayer) {
            return;
        }
        playerSurvivors = FindObjectsOfType<PlayerSurvivor>();
        Debug.Log($"Found survivors : {playerSurvivors.Length}");
    }

    private void Update() {
        if(!IsLocalPlayer) {
            return;
        }
        
        foreach(var player in playerSurvivors) {
            Vector3 playerPosition = player.transform.position;

            if(Vector3.Distance(playerPosition, transform.position) < detectDistance) {
                print("Survivor detected");
            }
        }
    }
}