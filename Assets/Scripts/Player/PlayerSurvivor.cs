using System;
using UnityEngine;
using Unity.Netcode;

public class PlayerSurvivor : NetworkBehaviour {
    private PlayerTaskManager taskManager;

    private Action OnAllTasksCompleted;

    private void Update() {
        if(taskManager.AllTaskCompleted()) {
            print("Done");
        }
    }
}