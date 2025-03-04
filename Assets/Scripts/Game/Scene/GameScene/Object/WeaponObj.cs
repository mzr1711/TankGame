using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponObj : MonoBehaviour
{
    public GameObject bullet;
    public Transform[] shootPos;

    public TankBaseObj ownerTankObj;

    public void Fire()
    {
        for(int i = 0; i < shootPos.Length; i++)
        {
            GameObject obj = Instantiate(bullet, shootPos[i].position, shootPos[i].rotation);
            obj.GetComponent<BulletObj>().ownerTankObj = ownerTankObj;
        }
    }

    public void SetOwner(TankBaseObj obj)
    {
        ownerTankObj = obj;
    }
}
