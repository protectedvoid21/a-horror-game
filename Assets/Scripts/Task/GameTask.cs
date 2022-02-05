using System;
using TMPro;
using UnityEngine;

public abstract class GameTask : MonoBehaviour {
    protected TextMeshProUGUI displayText;
    protected string description;

    protected int requiredCount;
    protected int collectedCount;

    public void Setup(TaskObject taskObject, TextMeshProUGUI displayText, Action onTaskCompleted) {
        description = taskObject.description;
        requiredCount = taskObject.requiredCount;
        this.displayText = displayText;
        onTaskCompleted += EndTask; 
        
        UpdateText();
    }

    public abstract void ActivateTask();

    //todo: This function should inform that task has been completed
    public void EndTask() {
        Utils.GreyTaskText(displayText);
    }

    public virtual bool IsCompleted() {
        return collectedCount == requiredCount;
    }

    protected virtual void UpdateText() {
        displayText.text = $"{description} : {collectedCount} / {requiredCount}";
    }
}