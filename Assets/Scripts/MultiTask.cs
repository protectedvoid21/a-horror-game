using System;
using TMPro;
using UnityEngine;

public class MultiTask : GameTask {
    [Serializable]
    private class TaskElement {
        public TaskObject taskObject;
        [HideInInspector] public int currentCount;
    }

    [SerializeField] private TaskElement[] taskElements;
    private int currentTaskIndex;

    private void Start() {
        if(taskElements.Length > 0) {
            SwitchTask(0);
        }
        else {
            Debug.LogError("MultiTask has not got any assigned tasks!");
        }
    }

    private void SwitchTask(int index) {
        TaskObject taskObject = taskElements[index].taskObject;
        
        description = taskObject.description;
        requiredCount = taskObject.requiredCount;
        //Setup nie wywoluje sie poniewaz monobehaviour musi "zyc" a spawnowanie objektow wywoluje sie w metodzie Start()
        taskObject.gameTask.Setup(taskObject, displayText);
        Instantiate(taskElements[index].taskObject.gameTask, gameObject.transform, true);
        UpdateText();
    }

    protected override void UpdateText() {
        displayText.text = description;
    }

    public override bool IsCompleted() {
        return currentTaskIndex == taskElements.Length;
    }

    public override void AddEndedTask() {
        currentTaskIndex++;

        if(IsCompleted()) {
            displayText.fontStyle = FontStyles.Strikethrough;
            displayText.color = Color.gray;
            return;
        }
        //Czy to nie pierdolnie?
        SwitchTask(currentTaskIndex);
    }
}