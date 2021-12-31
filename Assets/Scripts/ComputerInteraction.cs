using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ComputerInteraction : InteractableUIObject {
    [SerializeField] private GameObject buttonPanel;
    [Space]
    [SerializeField] private Button taskButton;
    [SerializeField] private GameObject cctvView;
    [SerializeField] private GameObject taskDownload;
    [SerializeField] private TextMeshProUGUI taskText;

    private DownloadTask downloadTask;

    public override void Enter() {
        base.Enter();
        
        buttonPanel.SetActive(true);
        
        if(downloadTask != null) {
            taskButton.interactable = !downloadTask.IsCompleted();

            if(downloadTask.IsCompleted()) {
                taskText.color = Color.gray;
                taskText.text = "Data downloaded";
            }
        }
        else {
            taskButton.interactable = false;
        }
    }

    public override void Exit() {
        base.Exit();
        
        taskDownload.SetActive(false);
        cctvView.SetActive(false);

        if(downloadTask != null) {
            if(!downloadTask.IsCompleted()) {
                downloadTask.StopDownload();
            }
        }
    }
    
    public void SetupDownloadTask(DownloadTask downloadTask) {
        this.downloadTask = downloadTask;
    }

    public void CctvView() {
        cctvView.SetActive(true);
        buttonPanel.SetActive(false);
    }

    public void TaskDownloadView() {
        buttonPanel.SetActive(false);
        taskDownload.SetActive(true);
    }
}