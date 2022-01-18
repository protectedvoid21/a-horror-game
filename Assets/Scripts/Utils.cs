using UnityEngine;
using TMPro;

public static class Utils {
    public static void EnableCursor() {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public static void DisableCursor() {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public static void GreyTaskText(TextMeshProUGUI text) {
        text.color = Color.gray;
        text.fontStyle = FontStyles.Strikethrough;
    }
}