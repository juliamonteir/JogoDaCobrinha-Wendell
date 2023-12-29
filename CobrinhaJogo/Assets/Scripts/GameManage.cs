using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManage : MonoBehaviour
{
   public Text scoreText;
   public Text hscoreText;
   public int score;
   public int hScore;
   
   public GameObject gameOverPanel, startPanel;
   
   public void SetScore(int value)
   {
      score += value;
      scoreText.text = "Score: " + score.ToString();
   }

   public void GameOver()
   {
      startPanel.SetActive(false);
      gameOverPanel.SetActive(true);

      if (score > hScore)
      {
         PlayerPrefs.SetInt("HScore", score);
         hscoreText.text = "New H-Score" + score.ToString();
      }
      
      Time.timeScale = 0;
   }

   public void Start()
   {
      Debug.Log(SceneManager.GetActiveScene().name);
      string nomedacena = SceneManager.GetActiveScene().name;
      if (nomedacena == "jogo")
      {
         Debug.Log("apagar cena");
         gameOverPanel.SetActive(false);
      }
   }

   public void Inicio()
   {
      SceneManager.LoadScene(1);
   }
}
