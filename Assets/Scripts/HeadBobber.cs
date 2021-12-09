﻿using UnityEngine;

public class HeadBobber : MonoBehaviour {
    public float walkingBobbingSpeed = 14f;
    public float bobbingAmount = 0.05f;
    [SerializeField] private PlayerController controller;

    private float defaultPosY = 0;
    private float timer = 0;

    private void Start() {
        defaultPosY = transform.localPosition.y;
    }

    private void Update() {
        if(Mathf.Abs(controller.moveDirection.x) > 0.1f || Mathf.Abs(controller.moveDirection.z) > 0.1f) {
            timer += Time.deltaTime * walkingBobbingSpeed;
            transform.localPosition = new Vector3(transform.localPosition.x, defaultPosY + Mathf.Sin(timer) * bobbingAmount,
                transform.localPosition.z);
        }
        else {
            timer = 0;
            transform.localPosition = new Vector3(transform.localPosition.x,
                Mathf.Lerp(transform.localPosition.y, defaultPosY, Time.deltaTime * walkingBobbingSpeed),
                transform.localPosition.z);
        }
    }
}
