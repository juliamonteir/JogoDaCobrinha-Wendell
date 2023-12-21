using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeTail : MonoBehaviour
{
   public Transform SnakeTailGfx;
   public float circleDiamenter;

   public GameObject tailPrefab;
   public List<Transform> tail = new List<Transform>();
   private List<Vector2> positions = new List<Vector2>();
   private static Vector2[] position;

   private void Start()
   {
      positions.Add(SnakeTailGfx.position);
   }

   private void Update()
   {
      float distance = ((Vector2)SnakeTailGfx.position - position[0]).magnitude;

      if (distance > circleDiamenter)
      {
         Vector2 direction = ((Vector2)SnakeTailGfx.position - positions[0]).normalized;
         
         positions.Insert(0, position[0] + direction * circleDiamenter);
         positions.RemoveAt(positions.Count - 1);

         distance -= circleDiamenter;
      }
      
      for (int i = 0; i < tail.Count; i++)
      {
         tail[i].position = Vector2.Lerp(position[i + 1], position[i], distance / circleDiamenter);
      }
   }

   public void AddTail()
   {
      GameObject newTail = Instantiate(tailPrefab, tail[tail.Count - 1].position, Quaternion.identity);
      tail.Add(newTail.transform);
   }
}
