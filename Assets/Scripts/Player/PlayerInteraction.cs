﻿using UnityEngine;

public class PlayerInteraction : MonoBehaviour {
    [SerializeField] private float interactionRange = 4f;
    public KeyCode InteractionKey;

    private OutlineObject hoveredObject;
    
    [SerializeField] private Camera playerCamera;
    [SerializeField] private LayerMask layerMask;

    private void Awake() {
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    private void Update() {
        if(Cursor.lockState == CursorLockMode.None) {
            return;
        }
        
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out RaycastHit hit, interactionRange, layerMask)) {
            OutlineObject outlineHit = hit.collider.GetComponent<OutlineObject>();
            DoInteraction(hit.collider.gameObject);

            if(outlineHit != null) {
                outlineHit.EnableOutline();
                if(hoveredObject != null) {
                    if(outlineHit.gameObject != hoveredObject.gameObject) {
                        hoveredObject.DisableOutline();
                    }
                }
                hoveredObject = outlineHit;
            }
            else {
                if(hoveredObject != null) {
                    hoveredObject.DisableOutline();
                    hoveredObject = null;
                }
            }
        }
        else {
            if(hoveredObject != null) {
                hoveredObject.DisableOutline();
                hoveredObject = null;
            }
        }
    }

    private void DoInteraction(GameObject interactionObject) {
        IInteractable interactableObject = interactionObject.GetComponent<IInteractable>();
        if(interactableObject == null) {
            return;
        }

        if(Input.GetKeyDown(InteractionKey)) {
            interactableObject.Interact();
        }
    }
}