using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TankBaseObj : MonoBehaviour
{
    public int atk;
    public int def;
    public int maxHp;
    public int hp;

    public float moveSpeed;
    public float roundSpeed;
    public float headRoundSpeed;

    public Transform tankHead;

    public GameObject deadEff;

    private int scoreValue = 10;

    public abstract void Fire();

    public virtual void Wound(TankBaseObj other)
    {
        int damage = other.atk - def;
        if (damage <= 0)
        {
            return;
        }
        hp -= damage;
        if(hp <= 0)
        {
            hp = 0;
            Dead();
        }
    }

    public virtual void Dead()
    {
        Destroy(gameObject);

        GamePanel.Instance.UpdateScore(scoreValue);

        if(deadEff != null)
        {
            GameObject effObj = Instantiate(deadEff, transform.position, transform.rotation);
            AudioSource aus = effObj.GetComponent<AudioSource>();
            aus.volume = GameDataManager.Instance.musicData.soundValue;
            aus.mute = !GameDataManager.Instance.musicData.isOpenSound;
            aus.Play();
        }
    }

    public virtual void Treat(int value)
    {
        hp += value;
        if(hp >= maxHp)
        {
            hp = maxHp;
        }
    }
}
