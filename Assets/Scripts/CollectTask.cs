using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectTask : GameTask {
    [SerializeField] private GameObject collectObject;
    [SerializeField] private Transform[] spawnPositions;
    [SerializeField] private int requiredCount;

    private int collectedCount;

    private void Start() {
        if(requiredCount > spawnPositions.Length) {
            Debug.LogWarning("Required count is greater than spawnPositions.Length");
        }

        int spawnCount = requiredCount > spawnPositions.Length ? requiredCount : spawnPositions.Length;
        List<int> spawnIndexList = new List<int>();

        for(int i = 0; i < spawnPositions.Length; i++) {
            spawnIndexList.Add(i);
        }
        
        for(int i = 0; i < spawnCount; i++) {
            int randomizedIndex = Random.Range(0, spawnIndexList.Count);
            Instantiate(collectObject, spawnPositions[spawnIndexList[randomizedIndex]].transform.position, Quaternion.identity);
            spawnIndexList.RemoveAt(randomizedIndex);
        }
    }
    
    public override bool IsCompleted() {
        return collectedCount == requiredCount;
    }

    public override void UpdateText() {
        displayText.text = $"{description} : {collectedCount} / {requiredCount}";

        if(IsCompleted()) {
            displayText.fontStyle = FontStyles.Strikethrough;
        }
    }
}