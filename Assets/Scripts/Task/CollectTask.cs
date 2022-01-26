using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class CollectTask : GameTask {
    [SerializeField] private TaskItem collectObject;
    [SerializeField] private Transform[] spawnPositions;
    [SerializeField] private bool useSpawnPositionRotation;

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
            Quaternion spawnRotation = useSpawnPositionRotation ? spawnPositions[i].rotation : collectObject.transform.rotation;
            TaskItem taskItem = Instantiate(collectObject, spawnPositions[spawnIndexList[randomizedIndex]].transform.position, spawnRotation);
            taskItem.Setup(this);
            spawnIndexList.RemoveAt(randomizedIndex);
        }
    }

    public void AddPickedUpItem() {
        collectedCount++;
        UpdateText();
    }
}