using System;
using UnityEngine;
using Unity.Netcode;

public class PlayerSurvivor : NetworkBehaviour {
    private PlayerTaskManager taskManager;
    private Action OnAllTasksCompleted;

    //it's terrible
    private bool taskFound;

    private void Update() {
        if(!IsLocalPlayer) {
            return;
        }
        if(!taskFound) {
            FindTaskManager();
            return;
        }

        if(taskManager.AllTaskCompleted()) {
            print("OnAllTasksCompleted invoked");
        }
    }

    //awful
    private void FindTaskManager() {
        taskManager = FindObjectOfType<PlayerTaskManager>();
        //end this pain fast
        if(taskManager == null) {
            return;
        }
        taskManager.Initialize();
        taskManager.PassActionReference(OnAllTasksCompleted);
        taskFound = true;
    }
}