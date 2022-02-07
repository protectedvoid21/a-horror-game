using System;
using UnityEngine;
using Unity.Netcode;

public class PlayerSurvivor : NetworkBehaviour {
    private PlayerTaskManager taskManager;

    private Action OnAllTasksCompleted;

    public override void OnNetworkSpawn() {
        if(!IsLocalPlayer) {
            return;
        }
        taskManager = FindObjectOfType<PlayerTaskManager>();
        taskManager.PassActionReference(OnAllTasksCompleted);
    }
    
    private void Update() {
        if(!IsLocalPlayer) {
            return;
        }
        if(taskManager.AllTaskCompleted()) {
            print("Done");
        }
    }
}