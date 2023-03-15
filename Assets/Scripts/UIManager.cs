using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text killCountText;
    public Text lvText;
    public GameMgr gameMgr;
    void Start()
    {
        gameMgr = GameObject.Find("GameMgr").GetComponent<GameMgr>();
    }


    void Update()
    {
        killCountText.text = "KILL : " + gameMgr.killCnt;
        lvText.text = "LV" + gameMgr.curLV;
    }

    public void RangeOff()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("AttackRange");
        for (int i = 0; i < objs.Length; i++)
        {
            objs[i].GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
