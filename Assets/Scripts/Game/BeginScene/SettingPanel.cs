using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPanel : BasePanel<SettingPanel>
{
    public CustomGUIButton btnClose;
    public CustomGUISlider sliderMusic;
    public CustomGUISlider sliderSound;
    public CustomGUIToggle toggleMusic;
    public CustomGUIToggle toggleSound;

    void Start()
    {
        btnClose.clickEvent += () =>
        {
            BeginPanel.Instance.ShowMe();
            HideMe();
        };
        sliderMusic.changeValue += (value) => GameDataManager.Instance.ChangeMusicValue(value);
        sliderSound.changeValue += (value) => GameDataManager.Instance.ChangeSoundValue(value);
        toggleMusic.changeValue += (value) => GameDataManager.Instance.OpenOrCloseMusic(value);
        toggleSound.changeValue += (value) => GameDataManager.Instance.OpenOrCloseSound(value);
        // ³õÊ¼Ê±Òþ²Ø
        HideMe();
    }

    private void UpdatePanelInfo()
    {
        MusicData data = GameDataManager.Instance.musicData;
        sliderMusic.nowValue = data.musicValue;
        sliderSound.nowValue = data.soundValue;
        toggleMusic.isSel = data.isOpenMusic;
        toggleSound.isSel = data.isOpenSound;
    }

    public override void ShowMe()
    {
        base.ShowMe();
        UpdatePanelInfo();
    }
}
