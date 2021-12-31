using UnityEngine;

public class InteractionOpen : OutlineObject, IInteractable {
    [SerializeField] private InteractableUIObject interactableUIObject;
    
    public void Interact() {
        interactableUIObject.Enter();
    }
}
