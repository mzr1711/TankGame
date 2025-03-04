using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerObj : TankBaseObj
{
    public GameObject[] weapons;
    public WeaponObj nowWeapon;
    private int weaponIndex = -1;
    public Transform weaponMount;

    public float upMoveSpeed;
    private bool isSpeedUp = false;
    public float maxSpeedUpTime = 5f;
    private float speedUpTimer = 0;
    private float preMoveSpeed;


    private bool isCursorLocked = true;

    void Start()
    {
        isSpeedUp = false;
        speedUpTimer = 0;
        preMoveSpeed = moveSpeed;
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

        Cursor.lockState = isCursorLocked ? CursorLockMode.Locked : CursorLockMode.None;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isCursorLocked = !isCursorLocked;
        }

        if (isSpeedUp)
        {
            speedUpTimer += Time.deltaTime;
            if (speedUpTimer >= maxSpeedUpTime)
            {
                speedUpTimer = 0;
                SpeedRecover();
            }
        }
    }

    public void ChangeWeapon()
    {
        if (nowWeapon != null)
        {
            Destroy(nowWeapon.gameObject);
        }
        int index = Random.Range(0, weapons.Length);
        while (index == weaponIndex)
        {
            index = Random.Range(0, weapons.Length);
        }
        GameObject weapon = Instantiate(weapons[index], weaponMount);
        nowWeapon = weapon.GetComponent<WeaponObj>();
        nowWeapon.SetOwner(this);
        weaponIndex = index;
    }

    public override void Fire()
    {
        if (nowWeapon != null)
        {
            nowWeapon.Fire();
        }
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

    public void ChangeAtk(int value)
    {
        atk += value;
    }

    public void ChangeDef(int value)
    {
        def += value;
    }

    public void SpeedUp()
    {
        isSpeedUp = true;
        moveSpeed = upMoveSpeed;
    }

    public void SpeedRecover()
    {
        isSpeedUp = false;
        moveSpeed = preMoveSpeed;
    }
}
