using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ComputerInteraction : InteractableUIObject {
    [SerializeField] private GameObject buttonPanel;
    [SerializeField] private Transform viewsObject;
    [Space]
    [SerializeField] private Button taskButton;
    [SerializeField] private GameObject cctvView;
    [SerializeField] private Camera[] cctvCameras;
    private GameObject downloadObject;
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
        cctvView.SetActive(false);
        foreach(var camera in cctvCameras) {
            camera.enabled = false;
        }

        if(downloadTask != null) {
            downloadObject.SetActive(false);
            if(!downloadTask.IsCompleted()) {
                downloadTask.StopDownload();
            }
        }
        
        base.Exit();
    }
    
    public void SetupDownloadTask(DownloadTask downloadTask) {
        this.downloadTask = downloadTask;
        downloadTask.transform.SetParent(viewsObject, false);
        downloadObject = downloadTask.gameObject;
        downloadObject.SetActive(false);
    }

    public void CctvView() {
        buttonPanel.SetActive(false);

        foreach(var camera in cctvCameras) {
            camera.enabled = true;
        }
        cctvView.SetActive(true);
    }

    public void TaskDownloadView() {
        buttonPanel.SetActive(false);
        downloadObject.SetActive(true);
    }
}