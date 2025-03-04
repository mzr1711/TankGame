using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankTowerObj : TankBaseObj
{
    public GameObject bulletObj;
    public Transform[] shootPos;

    public float fireOffsetTime = 1f;
    private float fireTimer = 0;

    void Start()
    {
        
    }

    void Update()
    {
        fireTimer += Time.deltaTime;
        if (fireTimer > fireOffsetTime)
        {
            fireTimer = 0;
            Fire();
        }
    }

    public override void Fire()
    {
        for (int i = 0; i < shootPos.Length; i++)
        {
            GameObject obj = Instantiate(bulletObj, shootPos[i].transform.position, shootPos[i].transform.rotation);
            obj.GetComponent<BulletObj>().SetOwner(this);
        }
    }
}
