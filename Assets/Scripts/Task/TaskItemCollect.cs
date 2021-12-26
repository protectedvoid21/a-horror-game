using UnityEngine;

public class TaskItemCollect : TaskItem {
    public override void Interact() {
        onTaskEnded?.Invoke();
        Destroy(gameObject);
    }
}