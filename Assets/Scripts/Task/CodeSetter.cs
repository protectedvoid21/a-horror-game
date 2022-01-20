using System;
using TMPro;
using UnityEngine;

public class CodeSetter : MonoBehaviour {
    public int Value { get; private set; }
    [SerializeField] private TextMeshProUGUI numberText;
    
    public void ChangeNumber(int amount) {
        Value += amount;
        Value %= 10;
        if(Value < 0) {
            Value = 9;
        }
        numberText.text = Value.ToString();
    }
}