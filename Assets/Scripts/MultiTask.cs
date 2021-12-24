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

    private GameTask currentTask;

    public override void ActivateTask() {
        if(taskElements.Length > 0) {
            currentTask = SwitchTask(0);
        }
        else {
            Debug.LogError("MultiTask has not got any assigned tasks!");
        }
    }

    private void Update() {
        if(currentTask.IsCompleted()) {
            AddEndedTask();
        }
    }

    //switch task nie wywoluje sie bo zaden przedmiot nie wie o odwolaniu sie do tej klasy po zakonczeniu taska
    private GameTask SwitchTask(int index) {
        TaskObject taskObject = taskElements[index].taskObject;
        
        description = taskObject.description;
        requiredCount = taskObject.requiredCount;
        GameTask gameTask = Instantiate(taskObject.gameTask, gameObject.transform, true);
        gameTask.Setup(taskObject, displayText);
        gameTask.ActivateTask();
        UpdateText();

        return gameTask;
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
        displayText.fontStyle = FontStyles.Normal;
        displayText.color = Color.white;
        
        currentTask = SwitchTask(currentTaskIndex);
    }
}