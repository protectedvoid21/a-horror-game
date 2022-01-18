using UnityEngine;

public abstract class InteractableUIObject : MonoBehaviour {
    [SerializeField] private GameObject mainPanel;

    public virtual void Enter() {
        Utils.EnableCursor();
        mainPanel.SetActive(true);
    }

    public virtual void Exit() {
        Utils.DisableCursor();
        mainPanel.SetActive(false);
    }
}