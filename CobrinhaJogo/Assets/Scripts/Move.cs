using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] Vector2 direction;

    private void Update()
    {
        float xAxis = Input.GetAxisRaw("Horizontal");
        float YAxis = Input.GetAxisRaw("Vertical");

        if (xAxis != 0)
            direction = Vector2.right * xAxis;
        if (YAxis != 0)
            direction = Vector2.up * YAxis;
    }

    private void FixedUpdate()
    {
        MoveSnake();
    }

    void MoveSnake()
    {
        float roundPosX = Mathf.Round(transform.position.x);
        float roundPosY = Mathf.Round(transform.position.y);
        
        transform.position = new Vector2(roundPosX + direction.x, roundPosY + direction.y);
    }
}