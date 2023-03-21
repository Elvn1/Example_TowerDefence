using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController_NavMesh : MonoBehaviour
{
    public CharacterController characterController;
    public Transform curTargetPos;
    public float moveSpeed = 5f;
    public float rotationSpeed = 10f;
    public int enemyHp = 100;
    private bool isDead = false;
    public GameMgr gameMgr;
    public GameObject deadEffect;
    public NavMeshAgent nav;
    void Start()
    {
        gameMgr = GameObject.Find("GameMgr").GetComponent<GameMgr>();
        characterController = GetComponent<CharacterController>();
        curTargetPos = GameObject.Find("Destroyer").transform;
        nav = GetComponent<NavMeshAgent>();
        nav.SetDestination(curTargetPos.position);
    }


    public void DamageByBullet(int dmg)
    {
        if(isDead == false)
        {
            enemyHp -= dmg;
            if(enemyHp <= 0)
            {
                isDead = true;
                gameMgr.killCnt++;
                Instantiate(deadEffect, transform.position, transform.rotation);
                GetComponentInChildren<HUDHpBar>().DestroyHpBar();
                Destroy(gameObject);
            }
        }
    }
}
