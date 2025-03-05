using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        PlayerObj player = other.GetComponent<PlayerObj>();
        if(player != null)
        {
            Cursor.lockState = CursorLockMode.None;
            player.isCursorLocked = false;
            Time.timeScale = 0;
            WinPanel.Instance.ShowMe();
        }
    }
}
