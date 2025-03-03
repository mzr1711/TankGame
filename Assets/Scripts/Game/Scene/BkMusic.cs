using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BkMusic : MonoBehaviour
{
    private static BkMusic instance;

    public static BkMusic Instance => instance;

    private AudioSource aus;

    void Awake()
    {
        instance = this;
        aus = GetComponent<AudioSource>();

        ChangeValue(GameDataManager.Instance.musicData.musicValue);
        ChangeOpen(GameDataManager.Instance.musicData.isOpenMusic);
    }

    public void ChangeValue(float value)
    {
        aus.volume = value;
    }

    public void ChangeOpen(bool isOpen)
    {
        aus.mute = !isOpen;
    }
}
