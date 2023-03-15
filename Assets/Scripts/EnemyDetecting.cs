using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetecting : MonoBehaviour
{
    public List<GameObject> enemies;
    public TowerController towerController;

    void Start()
    {
        towerController = transform.parent.GetComponent<TowerController>();
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            towerController.targetEnemy = other.gameObject;
            towerController.towerState = TowerController.TOWERSTATE.ATTACK;
            enemies.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            enemies.Remove(other.gameObject);
        }
    }
}
