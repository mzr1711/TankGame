using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 这是一个游戏管理数据类，使用单例模式
/// </summary>
public class GameDataManager
{
    private static GameDataManager instance = new GameDataManager();
    public static GameDataManager Instance { get => instance; }

    public MusicData musicData;
    public RankList rankList;

    private GameDataManager()
    {
        musicData = PlayerPrefsDataManager.Instance.LoadData(typeof(MusicData), "MusicData") as MusicData;
        if (!musicData.notFirstLoad)
        {
            musicData.isOpenMusic = true;
            musicData.isOpenSound = true;
            musicData.musicValue = 1;
            musicData.soundValue = 1;
            musicData.notFirstLoad = true;
        }
        PlayerPrefsDataManager.Instance.SaveData(musicData, "MusicData");

        rankList = PlayerPrefsDataManager.Instance.LoadData(typeof(RankList), "RankList") as RankList;
    }

    public void AddRankData(string playerName, int score, float time)
    {
        rankList.list.Add(new RankData(playerName, score, time));
        rankList.list.Sort((a, b) => a.time < b.time ? -1 : 1);
        for(int i = rankList.list.Count - 1; i >= 8; i--)
        {
            rankList.list.RemoveAt(i);
        }
        PlayerPrefsDataManager.Instance.SaveData(rankList, "RankList");
    }

    public void ChangeMusicValue(float value)
    {
        musicData.musicValue = value;
        BkMusic.Instance.ChangeValue(value);
        PlayerPrefsDataManager.Instance.SaveData(musicData, "MusicData");
    }

    public void ChangeSoundValue(float value)
    {
        musicData.soundValue = value;
        PlayerPrefsDataManager.Instance.SaveData(musicData, "MusicData");
    }

    public void OpenOrCloseMusic(bool isOpen)
    {
        musicData.isOpenMusic = isOpen;
        BkMusic.Instance.ChangeOpen(isOpen);
        PlayerPrefsDataManager.Instance.SaveData(musicData, "MusicData");
    }

    public void OpenOrCloseSound(bool isOpen)
    {
        musicData.isOpenSound = isOpen;
        PlayerPrefsDataManager.Instance.SaveData(musicData, "MusicData");
    }
}
