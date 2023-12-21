using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Food : MonoBehaviour
{
   [SerializeField] private BoxCollider2D spawArea;

   private void Start()
   {
      RandomPositionFood();
   }

   public void RandomPositionFood()
   {
      Bounds bounds = spawArea.bounds;

      Vector2 randonArea = new Vector2(Random.Range(bounds.min.x, bounds.max.x), Random.Range(bounds.min.y, bounds.max.y));

      float roundXPos = Mathf.Round(randonArea.x);
      float roundYPos = Mathf.Round(randonArea.y);

      transform.position = new Vector2(roundXPos, roundYPos);
   }

   private void OnTriggerEnter2D(Collider2D col)
   {
      if(col.CompareTag("Player"))
         RandomPositionFood();
   }
}
