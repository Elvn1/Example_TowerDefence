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

        if (isRunning) //(isRunning == true)와 같음
        {
            curTime += Time.deltaTime;
            if(curTime > coolTime) //1. 만약 쿨타임이 찼다면
            {
                curTime = 0; //2. curTime =0으로 초기화
                GameObject enemy = Instantiate(enemyPrefab, transform.position, transform.rotation); //3. enemyPrefab 생성
                //enemy.transform.position = transform.position; //4. enemy 위치 이동
                enemy.name = "Enemy_" + enemyCnt; //5. 에너미 이름 변경
                enemy.GetComponent<EnemyController>().enemyHp = gameMgr.curEnemyHp;
                enemy.GetComponent<EnemyController>().moveSpeed = gameMgr.curEnemySpeed;
                enemyMaxCnt = gameMgr.stageEnemyCnt;
                enemyCnt++; //6. enemyCnt 추가
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
