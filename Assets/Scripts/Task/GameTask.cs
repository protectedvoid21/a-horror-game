using TMPro;
using UnityEngine;

public abstract class GameTask : MonoBehaviour, ITask {
    protected TextMeshProUGUI displayText;
    protected string description;

    protected int requiredCount;
    protected int collectedCount;

    public void Setup(TaskObject taskObject, TextMeshProUGUI displayText) {
        description = taskObject.description;
        requiredCount = taskObject.requiredCount;
        this.displayText = displayText;
        
        UpdateText();
    }

    public abstract void ActivateTask();

    public virtual bool IsCompleted() {
        return collectedCount == requiredCount;
    }

    protected virtual void UpdateText() {
        displayText.text = $"{description} : {collectedCount} / {requiredCount}";

        if(IsCompleted()) {
            Utils.GreyTaskText(displayText);
        }
    }

    public abstract void AddEndedTask();
}