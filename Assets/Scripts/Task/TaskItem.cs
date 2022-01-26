using System;
using UnityEngine;

public class TaskItem : OutlineObject, IInteractable {
    private Action onItemPickedUp;

    private void OnValidate() {
        requireHover = false;
        highlightRange = 15f;
    }

    public void Setup(CollectTask collectTask) {
        onItemPickedUp = collectTask.AddPickedUpItem;
    }

    public void Interact() {
        onItemPickedUp?.Invoke();
        Destroy(gameObject);
    }
}