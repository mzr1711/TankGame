using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPanel : BasePanel<WinPanel>
{
    public CustomGUIButton btnConfirm;
    public CustomGUIInput inputFrame;

    void Start()
    {
        btnConfirm.clickEvent += () =>
        {
            Time.timeScale = 1;

            GameDataManager.Instance.AddRankData(inputFrame.content.text,
                GamePanel.Instance.nowScore, GamePanel.Instance.nowTime);

            SceneManager.LoadScene("BeginScene");
        };

        HideMe();
    }
}
