using TMPro;
using UnityEngine;

public abstract class GameTask : MonoBehaviour, ITask {
    [HideInInspector] public TextMeshProUGUI displayText;
    protected string description;
    
    public void SetText(string text) {
        if(string.IsNullOrEmpty(description)) {
            description = text;
        }
    }
    
    public abstract bool IsCompleted();

    public abstract void UpdateText();
}