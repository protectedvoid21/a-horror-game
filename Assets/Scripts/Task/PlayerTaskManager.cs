using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerTaskManager : MonoBehaviour {
    [SerializeField] private TaskObjectList taskObjectList;
    [SerializeField] private TextMeshProUGUI[] taskTexts;

    [SerializeField] private int requiredTasksToStart = 3;

    public List<TaskObject> Tasks { get; private set; } = new List<TaskObject>();

    private void Start() {
        foreach(var taskText in taskTexts) {
            taskText.text = "";
        }
        
        if(taskObjectList.taskObjects.Length < requiredTasksToStart) {
            Debug.LogWarning("Not enough tasks");
            return;
        }
        
        while(Tasks.Count < requiredTasksToStart) {
            int rng = Random.Range(0, taskObjectList.taskObjects.Length);
            
            if(!Tasks.Contains(taskObjectList.taskObjects[rng])) { 
                Tasks.Add(taskObjectList.taskObjects[rng]);
            }
        }

        for(int i = 0; i < Tasks.Count; i++) {
            GameTask gameTask = Instantiate(Tasks[i].gameTask, transform, true);
            gameTask.Setup(Tasks[i], taskTexts[i]);
            gameTask.ActivateTask();
        }
    }
}