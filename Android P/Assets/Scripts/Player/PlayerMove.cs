using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rig;
    public Joystick joystick;
    
    [SerializeField] private float speed;
    private float moveX;
    private float moveY;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        moveX = joystick.Horizontal;
        moveY = joystick.Vertical;
    }

    private void FixedUpdate()
    {
        rig.velocity = new Vector2(moveX * speed * Time.deltaTime, moveY * speed * Time.deltaTime);
    }
}
