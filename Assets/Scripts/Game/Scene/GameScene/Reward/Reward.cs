using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RewardType
{
    Weapon,
    HP,
    ATK,
    DEF,
    SPEED
};

public class Reward : MonoBehaviour
{
    public GameObject getEff;

    public RewardType type;

    private int treatValue = 20;
    private int atkAddValue = 10;
    private int defAddValue = 5;

    private int scoreValue = 2;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GamePanel.Instance.UpdateScore(scoreValue);

            PlayerObj player = other.GetComponent<PlayerObj>();

            switch (type)
            {
                case RewardType.Weapon: RewardWeapon(player); break;
                case RewardType.HP: RewardHp(player); break;
                case RewardType.ATK: RewardAtk(player); break;
                case RewardType.DEF: RewardDef(player); break;
                case RewardType.SPEED: RewardSpeed(player); break;
            }

            GameObject eff = Instantiate(getEff, transform.position, transform.rotation);
            AudioSource aus = eff.GetComponent<AudioSource>();
            aus.volume = GameDataManager.Instance.musicData.soundValue;
            aus.mute = !GameDataManager.Instance.musicData.isOpenSound;
        }
    }

    private void RewardWeapon(PlayerObj player)
    {
        Destroy(gameObject);

        player.ChangeWeapon();
    }

    private void RewardHp(PlayerObj player)
    {
        Destroy(gameObject);

        player.Treat(treatValue);
    }

    private void RewardAtk(PlayerObj player)
    {
        Destroy(gameObject);

        player.ChangeAtk(atkAddValue);
    }

    private void RewardDef(PlayerObj player)
    {
        Destroy(gameObject);

        player.ChangeDef(defAddValue);
    }

    private void RewardSpeed(PlayerObj player)
    {
        Destroy(gameObject);

        player.SpeedUp();
    }
}
