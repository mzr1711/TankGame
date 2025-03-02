using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����һ����Ϸ���������࣬ʹ�õ���ģʽ
/// </summary>
public class GameDataManager
{
    private static GameDataManager instance = new GameDataManager();
    public static GameDataManager Instance { get => instance; }

    public MusicData musicData;

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
    }

    public void ChangeMusicValue(float value)
    {
        musicData.musicValue = value;
        PlayerPrefsDataManager.Instance.SaveData(musicData, "MusicData");
    }

    public void ChangeSoundValue(float value)
    {
        musicData.soundValue = value;
        PlayerPrefsDataManager.Instance.SaveData(musicData, "MusicData");
    }

    public void OpenOrCloseMusic(bool value)
    {
        musicData.isOpenMusic = value;
        PlayerPrefsDataManager.Instance.SaveData(musicData, "MusicData");
    }

    public void OpenOrCloseSound(bool value)
    {
        musicData.isOpenSound = value;
        PlayerPrefsDataManager.Instance.SaveData(musicData, "MusicData");
    }
}
