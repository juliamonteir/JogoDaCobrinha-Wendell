using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Move : MonoBehaviour
{
    [SerializeField] Vector2 direction;
    [SerializeField] private List<Transform> snakeBodies;
    [SerializeField] private Transform body;

    GameManage gM;

    private void Start()
    {
        gM = FindObjectOfType<GameManage>();
        snakeBodies = new List<Transform>();
        snakeBodies.Add(transform);
    }

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
        for (int i = snakeBodies.Count - 1; i > 0; i--)
        {
            snakeBodies[i].position = snakeBodies[i - 1].position;
        }

        MoveSnake();
    }

    void MoveSnake()
    {
        float roundPosX = Mathf.Round(transform.position.x);
        float roundPosY = Mathf.Round(transform.position.y);

        transform.position = new Vector2(roundPosX + direction.x, roundPosY + direction.y);
    }

    void GrowingSnake()
    {
        Transform SpawBody = Instantiate(body, snakeBodies[snakeBodies.Count - 1].position, Quaternion.identity);
        snakeBodies.Add(SpawBody);
        gM.SetScore(10);
    }

    public void BtnStartGame()
    {
        gM.gameOverPanel.SetActive(false);
        Time.timeScale = 1;
        transform.position = Vector2.zero;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.tag)
        {
            case "Food": 
                GrowingSnake();
                break;
            case "obstacles" :
                gM.GameOver();
                break;
        }
    }
}