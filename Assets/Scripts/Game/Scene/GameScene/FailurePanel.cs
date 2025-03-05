using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailurePanel : BasePanel<FailurePanel>
{
    public CustomGUIButton btnQuit;
    public CustomGUIButton btnAgain;

    void Start()
    {
        btnQuit.clickEvent += () =>
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("BeginScene");
        };
        btnAgain.clickEvent += () =>
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("GameScene");
        };

        HideMe();
    }
}
