using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed;
    public float rotSpeed;


    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        transform.Translate(0, 0, v * moveSpeed * Time.deltaTime);
        transform.Rotate(0, h * rotSpeed * Time.deltaTime, 0);
    }
}
