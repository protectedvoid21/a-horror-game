using UnityEngine;

public abstract class InteractableUIObject : MonoBehaviour {
    [SerializeField] private GameObject mainPanel;
    
    public virtual void Enter() {
        CursorUtils.EnableCursor();
        mainPanel.SetActive(true);
    }

    public virtual void Exit() {
        CursorUtils.DisableCursor();
        mainPanel.SetActive(false);
    }
}