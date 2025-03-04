using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeObj : MonoBehaviour
{
    public int maxHittedCount = 5;
    private int hittedCount = 0;

    public GameObject[] rewards;

    public GameObject breakEff;

    void OnTriggerEnter(Collider other)
    {
        hittedCount++;
        if(hittedCount >= maxHittedCount)
        {
            int index = Random.Range(0, 100);
            if (index < 30)
            {
                index = Random.Range(0, rewards.Length);
                Instantiate(rewards[index], transform.position, transform.rotation);
            }

            GameObject eff = Instantiate(breakEff, transform.position, transform.rotation);
            AudioSource aus = eff.GetComponent<AudioSource>();
            aus.volume = GameDataManager.Instance.musicData.soundValue;
            aus.mute = !GameDataManager.Instance.musicData.isOpenSound;

            Destroy(gameObject);
        }
    }
}
