using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerTaskManager : MonoBehaviour {
    [SerializeField] private TaskObjectList taskObjectList;
    private TextMeshProUGUI[] taskTexts;

    [SerializeField] private int requiredTasksToStart = 3;

    private Action OnTasksCompleted;
    private Action OnTaskCompletedPlayer;

    private List<TaskObject> tasks = new List<TaskObject>();
    private List<GameTask> gameTasks = new List<GameTask>();

    private bool started;
    
    private IEnumerator Create() {
        GameObject textObject = GameObject.FindGameObjectWithTag("TaskTexts");

        while(textObject == null) {
            textObject = GameObject.FindGameObjectWithTag("TaskTexts");
            yield return null;
        }

        taskTexts = textObject.GetComponentsInChildren<TextMeshProUGUI>();
    }

    public void Initialize() {
        StartCoroutine(Create());
        foreach(var taskText in taskTexts) {
            taskText.text = "";
        }
        OnTasksCompleted += MarkCompleted;

        if(taskObjectList.taskObjects.Length < requiredTasksToStart) {
            Debug.LogWarning("Not enough tasks");
            return;
        }
        
        while(tasks.Count < requiredTasksToStart) {
            int rng = Random.Range(0, taskObjectList.taskObjects.Length);
            
            if(!tasks.Contains(taskObjectList.taskObjects[rng])) { 
                tasks.Add(taskObjectList.taskObjects[rng]);
            }
        }

        for(int i = 0; i < tasks.Count; i++) {
            GameTask gameTask = Instantiate(tasks[i].gameTask, transform, true);
            gameTask.Setup(tasks[i], taskTexts[i], OnTasksCompleted);
            gameTask.ActivateTask();
            gameTasks.Add(gameTask);
        }

        started = true;
    }

    public void PassActionReference(Action onTasksCompletedSurvivor) {
        OnTaskCompletedPlayer = onTasksCompletedSurvivor;
    }

    private void MarkCompleted() {
        if(AllTaskCompleted()) {
            OnTaskCompletedPlayer?.Invoke();
        }
    }

    public bool AllTaskCompleted() {
        if(!started) {
            return false;
        }

        return gameTasks.TrueForAll(task => task.IsCompleted());
    }
}