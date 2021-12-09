using UnityEngine;

public class PlayerInteraction : MonoBehaviour {
    [SerializeField] private float interactionRange = 4f;
    public KeyCode InteractionKey;

    private OutlineObject hoveredObject;
    
    [SerializeField] private Camera playerCamera;

    private void Awake() {
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    private void Update() {
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out RaycastHit hit, interactionRange)) {
            OutlineObject outlineHit = hit.collider.GetComponent<OutlineObject>();

            if(outlineHit != null) {
                outlineHit.EnableOutline();
                hoveredObject = outlineHit;
                DoInteraction(hit.collider.gameObject);
            }
            else if(hoveredObject != null) {
                hoveredObject.DisableOutline();
                hoveredObject = null;
            }
        }
        else {
            if(hoveredObject != null) {
                hoveredObject.DisableOutline();
            }
        }
    }

    private void DoInteraction(GameObject interactionObject) {
        if(!Input.GetKeyDown(InteractionKey)) {
            return;
        }

        IInteractable interactableObject = interactionObject.GetComponent<IInteractable>();

        if(interactableObject != null) {
            interactableObject.Interact();
        }
    }
}