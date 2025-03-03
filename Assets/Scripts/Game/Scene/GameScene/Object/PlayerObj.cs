using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObj : TankBaseObj
{
    void Start()
    {

    }

    void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime);
        transform.Rotate(Vector3.up, roundSpeed * Input.GetAxis("Horizontal") * Time.deltaTime);
        tankHead.Rotate(Vector3.up, headRoundSpeed * Input.GetAxis("Mouse X") * Time.deltaTime);
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }
    public override void Fire()
    {

    }

    public override void Dead()
    {
        base.Dead();
    }

    public override void Wound(TankBaseObj other)
    {
        base.Wound(other);

        GamePanel.Instance.UpdateHP(maxHp, hp);
    }
}
