using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankData
{
    public string playerName;
    public int score;
    public float time;

    public RankData()
    {

    }

    public RankData(string playerName, int score, float time)
    {
        this.playerName = playerName;
        this.score = score;
        this.time = time;
    }
}

public class RankList
{
    public List<RankData> list;
}
