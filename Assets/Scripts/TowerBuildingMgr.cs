using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuildingMgr : MonoBehaviour
{
    public GameObject towerPrefab;
    public GameObject upgradePanel;
    public UpgradeMgr upgradeMgr;

    void Start()
    {
        
    }


    void Update()
    {
        if (upgradePanel.activeSelf == true)
            return;
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit))
            {
                //Debug.Log($"맞은놈::: {hit.collider.gameObject.tag}");
                switch (hit.collider.gameObject.tag)
                {
                    case "Block":
                        GameObject tower = Instantiate(towerPrefab);
                        tower.transform.position = hit.collider.transform.position
                            + new Vector3(0, hit.collider.transform.localScale.y, 0);
                        break;
                    case "Block_None":
                        Debug.Log("그곳에는 타워를 세울 수 없습니다.");
                        break;
                    case "Tower":
                        Debug.Log("타워가 선택 되었습니다.");
                        upgradePanel.SetActive(true);
                        upgradeMgr.upgradeTarget = hit.collider.gameObject;
                        hit.collider.transform.GetChild(1).GetComponent<MeshRenderer>().enabled = true;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
