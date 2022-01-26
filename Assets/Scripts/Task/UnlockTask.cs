using TMPro;
using UnityEngine;

public class UnlockTask : GameTask {
    private GameObject openableObject;
    [SerializeField] private string objectTag;

    private InteractionRotate interactionRotate;
    
    public override void ActivateTask() {
        openableObject = GameObject.FindWithTag(objectTag);
        interactionRotate = openableObject.AddComponent<InteractionRotate>();
    }

    public override bool IsCompleted() {
        if(interactionRotate != null) {
            if(interactionRotate.isOpen) {
                EndTask();
                return true;
            }
        }
        return false;
    }
}