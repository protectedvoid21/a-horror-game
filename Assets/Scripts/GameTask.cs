using TMPro;
using UnityEngine;

public abstract class GameTask : MonoBehaviour, ITask {
    [HideInInspector] public TextMeshProUGUI displayText;
    private string _description;
    public string Description {
        set {
            if(string.IsNullOrEmpty(_description)) {
                _description = value;
            }
        }
    }

    [SerializeField] protected int requiredCount;
    private int collectedCount;

    public bool IsCompleted() {
        return collectedCount == requiredCount;
    }

    public void UpdateText() {
        displayText.text = $"{_description} : {collectedCount} / {requiredCount}";

        if(IsCompleted()) {
            displayText.fontStyle = FontStyles.Strikethrough;
        }
    }

    public void AddEndedTask() {
        collectedCount++;
        UpdateText();
    }
}