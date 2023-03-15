using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMaker : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float curTime;
    public float coolTime;
    public int enemyCnt = 0;
    public int enemyMaxCnt = 0;
    public GameMgr gameMgr;
    public bool isRunning = false;

    void Start()
    {
        gameMgr = GameObject.Find("GameMgr").GetComponent<GameMgr>();
        isRunning = true;
    }


    void Update()
    {
        if (enemyCnt > enemyMaxCnt)
            isRunning = false;

        if (isRunning) //(isRunning == true)�� ����
        {
            curTime += Time.deltaTime;
            if(curTime > coolTime) //1. ���� ��Ÿ���� á�ٸ�
            {
                curTime = 0; //2. curTime =0���� �ʱ�ȭ
                GameObject enemy = Instantiate(enemyPrefab, transform.position, transform.rotation); //3. enemyPrefab ����
                //enemy.transform.position = transform.position; //4. enemy ��ġ �̵�
                enemy.name = "Enemy_" + enemyCnt; //5. ���ʹ� �̸� ����
                enemy.GetComponent<EnemyController>().enemyHp = gameMgr.curEnemyHp;
                enemy.GetComponent<EnemyController>().moveSpeed = gameMgr.curEnemySpeed;
                enemyMaxCnt = gameMgr.stageEnemyCnt;
                enemyCnt++; //6. enemyCnt �߰�
            }
        }
    }

    public void InitEnemyMaker()
    {
        enemyCnt = 0;
        isRunning = true;
        gameMgr.curLV++;
        gameMgr.StageLvUp();
    }
}