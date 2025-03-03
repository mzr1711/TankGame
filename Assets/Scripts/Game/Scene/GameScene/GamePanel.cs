using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePanel : BasePanel<GamePanel>
{
    public CustomGUILabel labelScore;
    public CustomGUILabel labelTime;

    public CustomGUIButton buttonQuit;
    public CustomGUIButton buttonSetting;

    public CustomGUITexture textureHPBk;
    public CustomGUITexture textureHP;

    [HideInInspector]
    public int nowScore = 0;
    [HideInInspector]
    public float nowTime = 0;
    private int time;

    void Start()
    {
        buttonQuit.clickEvent += () =>
        {
            QuitPanel.Instance.ShowMe();
            Time.timeScale = 0;
        };
        buttonSetting.clickEvent += () =>
        {
            SettingPanel.Instance.ShowMe();
            Time.timeScale = 0;
        };
    }

    void Update()
    {
        nowTime += Time.deltaTime;

        time = (int)nowTime;
        if(time >= 60)
        {
            labelTime.content.text = time / 60 + "∑÷" + time % 60 + "√Î";
        }
        else
        {
            labelTime.content.text = time + "√Î";
        }
    }

    public void UpdateScore(int value)
    {
        nowScore += value;
        labelScore.content.text = nowScore.ToString();
    }

    public void UpdateHP(int maxHP, int nowHP)
    {
        textureHP.guiPos.width = (float)nowHP / maxHP * textureHPBk.guiPos.width;
    }
}
