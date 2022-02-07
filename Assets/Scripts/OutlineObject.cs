using UnityEngine;

[RequireComponent(typeof(Outline))]
public class OutlineObject : MonoBehaviour {
    [SerializeField] protected bool requireHover = true;
    [SerializeField] protected float highlightRange = 3f;
    private Outline outline;

    private Transform playerTransform;

    private void Start() {
        outline = GetComponent<Outline>();
        outline.enabled = false;

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update() {
        if(requireHover) {
            return;
        }
        outline.enabled = Vector3.Distance(transform.position, playerTransform.position) < highlightRange;
    }

    public void EnableOutline() {
        outline.enabled = true;
    }

    public void DisableOutline() {
        outline.enabled = false;
    }
}