using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectTask : GameTask {
    [SerializeField] private TaskItem collectObject;
    [SerializeField] private Transform[] spawnPositions;
    
    public override void ActivateTask() {
        if(requiredCount > spawnPositions.Length) {
            Debug.LogWarning("Required count is greater than spawnPositions.Length");
        }

        int spawnCount = requiredCount < spawnPositions.Length ? requiredCount : spawnPositions.Length;
        List<int> spawnIndexList = new List<int>();

        for(int i = 0; i < spawnPositions.Length; i++) {
            spawnIndexList.Add(i);
        }
        
        for(int i = 0; i < spawnCount; i++) {
            int randomizedIndex = Random.Range(0, spawnIndexList.Count);
            TaskItem taskItem = Instantiate(collectObject, spawnPositions[spawnIndexList[randomizedIndex]].transform.position, Quaternion.identity);
            taskItem.Setup(this);
            spawnIndexList.RemoveAt(randomizedIndex);
        }
    }

    public override void AddEndedTask() {
        collectedCount++;
        UpdateText();
    }
}