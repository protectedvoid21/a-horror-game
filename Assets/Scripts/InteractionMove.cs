using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(OutlineObject))]
public class InteractionMove : MonoBehaviour, IInteractable {
    [SerializeField] private Vector3 movePosition;
    private IEnumerator movingObject;

    private Vector3 startPosition;
    private Vector3 openedPosition;

    private bool isOpen;

    private void Start() {
        startPosition = transform.localPosition;
        openedPosition = transform.localPosition + movePosition;
    }

    public void Interact() {
        Vector3 desiredPosition = isOpen ? startPosition : openedPosition;
        isOpen = !isOpen;
        
        StopAllCoroutines();
        
        movingObject = ChangePosition(desiredPosition);
        StartCoroutine(movingObject);
    }

    private IEnumerator ChangePosition(Vector3 desiredPosition) {
        while(transform.localPosition != desiredPosition) {
            transform.localPosition = Vector3.Lerp(transform.localPosition, desiredPosition, Time.deltaTime * 3f);
            yield return null;
        }
    }
}
