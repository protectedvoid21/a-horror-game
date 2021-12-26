using System.Collections;
using UnityEngine;

[RequireComponent(typeof(OutlineObject))]
public class InteractionRotate : MonoBehaviour, IInteractable {
    [SerializeField] private float rotationAmount = 100f;

    public bool isOpen { get; private set; }
    private IEnumerator openingDoor;

    private float startRotation;

    private void Start() {
        startRotation = transform.rotation.eulerAngles.y;
    }

    public void Interact() {
        float toRotation = isOpen ? startRotation : startRotation + rotationAmount;
        isOpen = !isOpen;
        
        StopAllCoroutines();
        
        openingDoor = ChangeDoorState(toRotation);
        StartCoroutine(openingDoor);
    }

    private IEnumerator ChangeDoorState(float toRotation) {
        while(transform.rotation.y != toRotation) {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.rotation.eulerAngles.x, toRotation, transform.rotation.eulerAngles.z), Time.deltaTime * 3f);
            yield return null;
        }
    }
}