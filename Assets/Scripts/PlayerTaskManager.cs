using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerTaskManager : MonoBehaviour {
    [SerializeField] private TaskObjectList taskObjectList;
    [SerializeField] private TextMeshProUGUI[] taskTexts;

    [SerializeField] private int requiredTasksToStart = 3;

    private List<TaskObject> tasks = new List<TaskObject>();

    private void Start() {
        foreach(var taskText in taskTexts) {
            taskText.text = "";
        }
        
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
            GameTask gameTask = Instantiate(tasks[i].gameTask, gameObject.transform, true);
            
            gameTask.Setup(tasks[i], taskTexts[i]);
        }
    }
}