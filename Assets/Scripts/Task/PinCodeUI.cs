using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PinCodeUI : InteractableUIObject {
    [SerializeField] private CodeSetter[] codeSetters;
    [SerializeField] private Button applyButton;
    [SerializeField] private TextMeshProUGUI statusText;
    [SerializeField] private TextMeshProUGUI pinText;

    private int[] code = new int[4];

    public void Start() {
        pinText.text = "PIN Code : ";
        for(int i = 0; i < 4; i++) {
            code[i] = Random.Range(0, 9);
            pinText.text += code[i].ToString();
        }
    }

    private void OnEnable() {
        statusText.text = "";
    }

    public void CheckCode() {
        for(int i = 0; i < 4; i++) {
            if(code[i] != codeSetters[i].Value) {
                statusText.text = "The PIN is incorrect";
                return;
            }
        }
        Debug.Log("PIN Applied");
        statusText.text = "PIN confirmation success";
        FindObjectOfType<PinTask>().EndTask();
        applyButton.enabled = false;
        enabled = false;
    }
}
