﻿using System;
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
    private Action OnTaskCompleted;

    private GameTask currentTask;

    public override void ActivateTask() {
        if(taskElements.Length > 0) {
            SwitchTask(0);
        }
        else {
            Debug.LogError("MultiTask has not got any assigned tasks!");
        }
    }

    private void Update() {
        if(currentTask == null) {
            return;
        }
        if(currentTask.IsCompleted()) {
            currentTaskIndex++;
            Destroy(currentTask.gameObject);
            if(IsCompleted()) {
                EndTask();
                //Destroy(gameObject);
                //z tym destroy to sie jeszcze moze wstrzymaj bo ci zylka peknie
                //mozliwe ze trzeba bedzie sprawdzic czy gracz wygral poprzez sprawdzenie dla kazdego taska IsCompleted
                return;
            }

            SwitchTask(currentTaskIndex);
        }
    }
    
    private void SwitchTask(int index) {
        TaskObject taskObject = taskElements[index].taskObject;
        
        description = taskObject.description;
        requiredCount = taskObject.requiredCount;
        
        currentTask = Instantiate(taskObject.gameTask, gameObject.transform, true);
        currentTask.Setup(taskObject, displayText, OnTaskCompleted);
        currentTask.ActivateTask();
        
        displayText.fontStyle = FontStyles.Normal;
        displayText.color = Color.white;
        UpdateText();
    }

    public override bool IsCompleted() {
        return currentTaskIndex == taskElements.Length;
    }
}