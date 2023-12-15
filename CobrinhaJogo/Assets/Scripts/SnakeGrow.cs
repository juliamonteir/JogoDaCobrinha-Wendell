using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeGrow : MonoBehaviour
{
   public SnakeTail snakeTail;

   private void Start()
   {
      snakeTail = FindObjectOfType<SnakeTail>();

      if (snakeTail == null)
      {
         Debug.Log("SnakeTail");
      }
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag("Snake"))
      {
         Destroy(gameObject, 0.02f);
         if (snakeTail != null)
         {
            snakeTail.AddTail();
         }
         else
         {
            Debug.Log("SnakeTail");
         }
      }
   }
}
