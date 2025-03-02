using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankPanel : BasePanel<RankPanel>
{
    public CustomGUIButton btnClose;

    private List<CustomGUILabel> rankList = new List<CustomGUILabel>();
    private List<CustomGUILabel> playerNameList = new List<CustomGUILabel>();
    private List<CustomGUILabel> scoreList = new List<CustomGUILabel>();
    private List<CustomGUILabel> timeList = new List<CustomGUILabel>();

    void Start()
    {
        for(int i = 1; i <= 8; i++)
        {
            rankList.Add(transform.Find("LabelRankParent/LabelRank" + i).GetComponent<CustomGUILabel>());
            playerNameList.Add(transform.Find("LabelPlayerNameParent/LabelPlayerName" + i).GetComponent<CustomGUILabel>());
            scoreList.Add(transform.Find("LabelScoreParent/LabelScore" + i).GetComponent<CustomGUILabel>());
            timeList.Add(transform.Find("LabelTimeParent/LabelTime" + i).GetComponent<CustomGUILabel>());
        }

        btnClose.clickEvent += () =>
        {
            BeginPanel.Instance.ShowMe();
            HideMe();
        };

        HideMe();
    }

    public override void ShowMe()
    {
        base.ShowMe();
        UpdatePanelInfo();
    }

    public void UpdatePanelInfo()
    {

    }
}
