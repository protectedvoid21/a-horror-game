using System;
using UnityEngine;
using Unity.Netcode;

public class PlayerSurvivor : NetworkBehaviour {
    private PlayerTaskManager taskManager;
    
    //private Action OnTaskCompleted;

    private void Start() {
        Instantiate(taskManager);
    }

    private void Update() {
        if(taskManager.AllTaskCompleted()) {
            print("Done");
        }
    }
}