using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankObj : TankBaseObj
{
    public Transform[] movePos;
    private int nowIndex = 0;

    public Transform[] shootPos;
    public GameObject bulletObj;

    public Transform targetPos;
    public float fireDist = 20f;
    private float distToTarget;

    public float fireOffsetTime = 0.5f;
    private float fireTimer = 0;

    #region GUIPart
    public float timeMaxHpShow = 4f;
    private float timerHpShow;
    public float maxShowDist = 30f;
    public float minShowDist = 1f;
    private Rect rectMaxHp;
    public Texture texMaxHp;
    private Rect rectHp;
    public Texture texHp;
    #endregion

    void Update()
    {
        if (targetPos != null)
            distToTarget = Vector3.Distance(transform.position, targetPos.position);
        else
            distToTarget = 100f;

        tankHead.transform.LookAt(targetPos);
        transform.LookAt(movePos[nowIndex]);
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, movePos[nowIndex].position) < 0.05f)
        {
            nowIndex++;
            if (nowIndex >= movePos.Length)
            {
                nowIndex = 0;
            }
        }

        if (distToTarget < fireDist)
        {
            fireTimer += Time.deltaTime;
            if (fireTimer > fireOffsetTime)
            {
                fireTimer = 0;
                Fire();
            }
        }
    }

    public override void Fire()
    {
        for (int i = 0; i < shootPos.Length; i++)
        {
            GameObject obj = Instantiate(bulletObj, shootPos[i].position, shootPos[i].rotation);
            obj.GetComponent<BulletObj>().SetOwner(this);
        }
    }

    public override void Wound(TankBaseObj other)
    {
        base.Wound(other);

        timerHpShow = timeMaxHpShow;
    }

    private void OnGUI()
    {
        if (distToTarget <= maxShowDist && timerHpShow > 0)
        {
            timerHpShow -= Time.deltaTime;

            Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

            screenPos.y = Screen.height - screenPos.y - Map(distToTarget, minShowDist, maxShowDist, 200, 50);
            screenPos.x = screenPos.x - Map(distToTarget, minShowDist, maxShowDist, 100, 20);

            rectMaxHp.y = screenPos.y;
            rectMaxHp.x = screenPos.x;
            rectMaxHp.width = Map(distToTarget, minShowDist, maxShowDist, 200, 50);
            rectMaxHp.height = Map(distToTarget, minShowDist, maxShowDist, 40, 10);
            GUI.DrawTexture(rectMaxHp, texMaxHp);
            rectHp.y = screenPos.y;
            rectHp.x = screenPos.x;
            rectHp.width = (float)hp / maxHp * rectMaxHp.width;
            rectHp.height = Map(distToTarget, minShowDist, maxShowDist, 40, 10);
            GUI.DrawTexture(rectHp, texHp);
        }
    }

    public float Map(float value, float startVal, float EndVal, float startRtnVal, float endRtnVal)
    {
        // ·ÀÖ¹Òç³öºÍ³ý0´íÎó
        if (startVal == EndVal || value < startVal) return startRtnVal;
        if (value > EndVal) return endRtnVal;

        float normalizedValue = (value - startVal) / (EndVal - startVal);

        float mappedValue = Mathf.Lerp(startRtnVal, endRtnVal, normalizedValue);

        return mappedValue;
    }
}
