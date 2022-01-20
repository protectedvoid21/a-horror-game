using UnityEngine;
/// <summary>
/// Gives an availability to interact with object and pass further information to InteractableUIObject
/// </summary>
[RequireComponent(typeof(OutlineObject))]
public class InteractionOpen : MonoBehaviour, IInteractable {
    [SerializeField] private InteractableUIObject interactableUIObject;
    
    public void Interact() {
        interactableUIObject.Enter();
    }

    public void InsertUIObject(InteractableUIObject interactableUIObject) {
        this.interactableUIObject = interactableUIObject;
    }
}
