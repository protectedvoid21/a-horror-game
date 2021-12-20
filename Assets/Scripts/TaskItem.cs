using System;
using UnityEngine;

public class TaskItem : OutlineObject, IInteractable {
    private Action onTaskEnded;

    public void Setup(GameTask gameTask) {
        onTaskEnded = gameTask.AddEndedTask;
    }

    public void Interact() {
        onTaskEnded?.Invoke();
        Destroy(gameObject);
    }
}