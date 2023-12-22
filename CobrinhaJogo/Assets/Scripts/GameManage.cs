using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManage : MonoBehaviour
{
   [SerializeField] Text scoreText;
   [SerializeField] int score;

   public GameObject gameOverPanel;
   
   public void SetScore(int value)
   {
      score += value;
      scoreText.text = "Score: " + score.ToString();
   }

   public void GameOver()
   {
      gameOverPanel.SetActive(true);
      Time.timeScale = 0;
   }
}
