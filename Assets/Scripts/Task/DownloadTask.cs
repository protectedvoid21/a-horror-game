﻿using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DownloadTask : GameTask {
    [SerializeField] private GameObject progressObject;
    [SerializeField] private Image progressBar;
    [SerializeField] private GameObject startButton;
    [SerializeField] private GameObject pressButtonToStartText;
    [SerializeField] private TextMeshProUGUI statusText;
    [SerializeField] private TextMeshProUGUI percentText;

    [SerializeField] private float duration = 5f;

    private bool downloadComplete;
    private IEnumerator downloadProcess;

    public void StartDownload() {
        startButton.SetActive(false);
        pressButtonToStartText.SetActive(false);
        progressObject.SetActive(true);
        statusText.gameObject.SetActive(true);
        
        downloadProcess = Download();
        StartCoroutine(downloadProcess);
    }

    public void StopDownload() {
        StopCoroutine(downloadProcess);
    }
    
    private IEnumerator Download() {
        progressBar.fillAmount = 0f;
        float time = 0f;

        while(time < duration) {
            progressBar.fillAmount = Mathf.Lerp(0f, 1f, time / duration);
            percentText.text = $"{(int)(progressBar.fillAmount * 100)}%";
            time += Time.deltaTime;
            yield return null;
        }

        progressBar.fillAmount = 1f;
        percentText.text = "100%";

        AddEndedTask();
    }

    public override void ActivateTask() {
        FindObjectOfType<ComputerInteraction>().SetupDownloadTask(this);
    }

    public override void AddEndedTask() {
        downloadComplete = true;
    }

    public override bool IsCompleted() {
        return downloadComplete;
    }
}