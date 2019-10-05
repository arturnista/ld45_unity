using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float acceleration;

    private new Rigidbody2D rigidbody2D;
    private Vector2 targetVelocity;
    private Vector2 moveVelocity;

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");

        targetVelocity = (new Vector2(hor, ver)).normalized * moveSpeed;
        
        moveVelocity = Vector2.MoveTowards(moveVelocity, targetVelocity, acceleration * Time.deltaTime);
    }

    void FixedUpdate()
    {
        rigidbody2D.MovePosition(
            rigidbody2D.position + (moveVelocity * Time.fixedDeltaTime)
        );
    }
    
}
