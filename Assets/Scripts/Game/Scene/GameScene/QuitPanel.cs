using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitPanel : BasePanel<QuitPanel>
{
    public CustomGUIButton btnQuit;
    public CustomGUIButton btnConfirm;
    public CustomGUIButton btnCancel;

    void Start()
    {
        btnQuit.clickEvent += () =>
        {
            HideMe();
        };
        btnConfirm.clickEvent += () =>
        {
            SceneManager.LoadScene("BeginScene");
        };
        btnCancel.clickEvent += () =>
        {
            HideMe();
        };

        HideMe();
    }

    public override void HideMe()
    {
        base.HideMe();
        Time.timeScale = 1;
    }
}
