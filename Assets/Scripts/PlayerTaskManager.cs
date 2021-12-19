using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerTaskManager : MonoBehaviour {
    [SerializeField] private TaskObjectList taskObjectList;
    [SerializeField] private TextMeshProUGUI[] taskTexts;

    [SerializeField] private int requiredTasksToStart = 3;

    private List<TaskObject> tasks;

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
            tasks[i].gameTask.displayText = taskTexts[i];
            tasks[i].gameTask.UpdateText();
            tasks[i].gameTask.SetText(tasks[i].description);

            Instantiate(tasks[i].gameTask, new Vector3(0, 0, 0), Quaternion.identity).transform.parent = gameObject.transform;
        }
    }
}