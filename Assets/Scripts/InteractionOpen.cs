using UnityEngine;

[RequireComponent(typeof(OutlineObject))]
public class InteractionOpen : MonoBehaviour, IInteractable {
    [SerializeField] private InteractableUIObject interactableUIObject;
    
    public void Interact() {
        interactableUIObject.Enter();
    }
}
