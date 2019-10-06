using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthBossMovement : MonoBehaviour
{
    private PlayerMovement playerMovement;

    private Vector2 direction;

    private Vector2 earthBossPosition;

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

        earthBossPosition = transform.position;
        playerPosition = playerMovement.transform.position;

        direction = playerPosition - earthBossPosition;
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
