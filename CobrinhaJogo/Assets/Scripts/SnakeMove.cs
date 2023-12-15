using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMove : MonoBehaviour
{
   public float speed = 3f;
   public float rotationSpeed = 200f;

   private float velX = 0f;

   private void Update()
   {
      velX = Input.GetAxisRaw("Horizontal");
   }

   private void FixedUpdate()
   {
      transform.Translate(Vector2.up * speed * Time.fixedDeltaTime, Space.Self);
      
      transform.Rotate(Vector3.forward * -velX * rotationSpeed * Time.fixedDeltaTime);
   }
}
