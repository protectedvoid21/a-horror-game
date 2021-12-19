using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Task List", menuName = "Task list")]
public class TaskObjectList : ScriptableObject {
    public TaskObject[] taskObjects;
}
