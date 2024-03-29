﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private PlayerMovement playerMovement;

    private Vector2 direction;

    private Vector2 enemyPosition;

    private Vector2 playerPosition;
    [SerializeField]
    private float speed;

    private Rigidbody2D rigidbody2d;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {

        rigidbody2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

    }

    void Start()
    {

        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();

    }

    void Update()
    {

        if(playerMovement == null) return;

        enemyPosition = transform.position;
        playerPosition = playerMovement.transform.position;

        direction = playerPosition - enemyPosition;
        direction.Normalize();

        if(rigidbody2d.velocity.x < 0) 
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }

    }

    void FixedUpdate()
    {

        rigidbody2d.velocity = direction * speed; 

    }
}
