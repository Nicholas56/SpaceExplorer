using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionSetup : MonoBehaviour
{
    [SerializeField] GameObject menu;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            if (menu.activeSelf == false) { StopTime(); }
            else { StartTime(); }
            menu.SetActive(!menu.activeSelf);
        }
    }

    public void StartTime()
    {
        Time.timeScale = 1;
        HideCursor();
    }

    public void StopTime()
    {
        Time.timeScale = 0;
        ShowCursor();
    }

    public void HideCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ShowCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
