using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletObj : MonoBehaviour
{
    public float moveSpeed = 20;

    public TankBaseObj ownerTankObj;
    public string ownerTag;

    public GameObject boomEffObj;

    void Start()
    {
        ownerTag = ownerTankObj.tag;
    }

    void Update()
    {
        transform.Translate(moveSpeed * Vector3.forward * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "Cube") ||
            (other.gameObject.tag == "Enemy" && ownerTag == "Player") ||
            (other.gameObject.tag == "Player" && ownerTag == "Enemy"))
        {
            TankBaseObj obj = other.GetComponent<TankBaseObj>();
            if(obj != null)
            {
                obj.Wound(ownerTankObj);
            }

            if (boomEffObj != null)
            {
                GameObject eff = Instantiate(boomEffObj, transform.position, transform.rotation);
                AudioSource aus = eff.GetComponent<AudioSource>();
                aus.volume = GameDataManager.Instance.musicData.soundValue;
                aus.mute = !GameDataManager.Instance.musicData.isOpenSound;
            }

            Destroy(gameObject);
        }
    }

    public void SetOwner(TankBaseObj obj)
    {
        ownerTankObj = obj;
    }
}
