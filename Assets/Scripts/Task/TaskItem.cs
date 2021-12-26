using System;
using UnityEngine;

public abstract class TaskItem : OutlineObject, IInteractable {
    protected Action onTaskEnded;

    private void OnValidate() {
        requireHover = false;
        highlightRange = 15f;
    }

    public void Setup(GameTask gameTask) {
        onTaskEnded = gameTask.AddEndedTask;
    }

    public abstract void Interact();
}