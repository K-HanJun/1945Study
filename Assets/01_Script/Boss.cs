using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Boss : MonoBehaviour
{
    private int flag = 1;
    private int speed = 1;

    public GameObject mb;
    public GameObject mb2;
    
    public Transform pos1;
    public Transform pos2;

    private void Start()
    {
        StartCoroutine(BossMissle());

        StartCoroutine(CircleFire());
    }

    IEnumerator BossMissle()
    {
        while (true)
        {
            // 미사일 두개
            Instantiate(mb, pos1.position, Quaternion.identity);
            Instantiate(mb, pos2.position, Quaternion.identity);

            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator CircleFire()
    {
        float attackRate = 3;
        int count = 30;
        float intervalAngle = 360 / count;
        float weightAngle = 0f;

        while (true)
        {
            for (int i = 0; i < count; ++i)
            {
                GameObject clone = Instantiate(mb2, transform.position, Quaternion.identity);

                float angle = weightAngle + intervalAngle * i;
                float x = Mathf.Cos(angle * Mathf.Deg2Rad);
                float y = Mathf.Sin(angle * Mathf.Deg2Rad);
                
                clone.GetComponent<BossBullet>().Move(new Vector2(x, y));
            }
            // 발사체가 생성되는 시작 각도 설정을 위한 변수
            weightAngle += 1;

            yield return new WaitForSeconds(attackRate);
        }
    }

    private void Update()
    {
        if (transform.position.x >= 1) flag *= -1;
        if(transform.position.x <= -1) flag *= -1;
        
        transform.Translate(flag * speed * Time.deltaTime, 0, 0);
    }
}
