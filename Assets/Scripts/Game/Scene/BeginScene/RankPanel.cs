using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankPanel : BasePanel<RankPanel>
{
    public CustomGUIButton btnClose;

    private List<CustomGUILabel> playerNameList = new List<CustomGUILabel>();
    private List<CustomGUILabel> scoreList = new List<CustomGUILabel>();
    private List<CustomGUILabel> timeList = new List<CustomGUILabel>();

    void Start()
    {
        for(int i = 1; i <= 8; i++)
        {
            playerNameList.Add(transform.Find("LabelPlayerNameParent/LabelPlayerName" + i).GetComponent<CustomGUILabel>());
            scoreList.Add(transform.Find("LabelScoreParent/LabelScore" + i).GetComponent<CustomGUILabel>());
            timeList.Add(transform.Find("LabelTimeParent/LabelTime" + i).GetComponent<CustomGUILabel>());
        }

        btnClose.clickEvent += () =>
        {
            BeginPanel.Instance.ShowMe();
            HideMe();
        };

        //GameDataManager.Instance.AddRankData("≤‚ ‘–’√˚", 50, 400);

        HideMe();
    }

    public override void ShowMe()
    {
        base.ShowMe();
        UpdatePanelInfo();
    }

    public void UpdatePanelInfo()
    {
        List<RankData> list = GameDataManager.Instance.rankList.list;
        for(int i = 0; i < list.Count; i++)
        {
            playerNameList[i].content.text = list[i].playerName;
            scoreList[i].content.text = list[i].score.ToString();
            string timeText = "";
            int time = (int)list[i].time;
            if (time >= 60)
            {
                timeText += time / 60 + "∑÷" + time % 60 + "√Î";
            }
            else
            {
                timeText += time + "√Î";
            }
            timeList[i].content.text = timeText;
        }
    }
}
