using System.Collections;
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

    void Awake()
    {

        rigidbody2d = GetComponent<Rigidbody2D>();

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

    }

    void FixedUpdate()
    {

        rigidbody2d.velocity = direction * speed; 

    }
}
