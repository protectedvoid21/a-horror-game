using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Task", menuName = "Task")]
public class TaskObject : ScriptableObject {
    public string description;
    public int requiredCount;
    public GameTask gameTask;
}
