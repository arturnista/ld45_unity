using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float acceleration;
    [SerializeField]
    private GameObject runEffectPrefab;

    private SpriteRenderer spriteRenderer;

    private new Rigidbody2D rigidbody2D;
    private Vector2 targetVelocity;
    private Vector2 moveVelocity;
    public Vector2 MoveVelocity { get { return moveVelocity;} }
    private Vector2 lookDirection;
    public Vector2 LookDirection { get { return lookDirection;} }


    private float lastHorizontal;
    private float lastVertical;

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");

        targetVelocity = (new Vector2(hor, ver)).normalized * moveSpeed;
        
        moveVelocity = Vector2.MoveTowards(moveVelocity, targetVelocity, acceleration * Time.deltaTime);

        if(hor != 0 || ver != 0)
        {
            lookDirection = (new Vector2(hor, ver)).normalized;
        }

        Debug.DrawRay(transform.position, lookDirection);

        if(Mathf.Abs(hor) > .01f)
        {
            Vector3 scale = transform.localScale;
            scale.x = hor < 0 ? -1 : 1;
            transform.localScale = scale;
        }

        if(hor != 0)
        {
            if(lastHorizontal == 0) PlayRunEffect();
            else if(Mathf.Sign(lastHorizontal) != Mathf.Sign(hor)) PlayRunEffect();
        }

        lastHorizontal = hor;
        lastVertical = ver;

    }

    void FixedUpdate()
    {
        rigidbody2D.MovePosition(
            rigidbody2D.position + (moveVelocity * Time.fixedDeltaTime)
        );
    }

    void PlayRunEffect()
    {
        Vector3 spawnOffset = new Vector3(-0.2f, -0.5f);
        Quaternion rotation = Quaternion.identity;
        
        if(targetVelocity.x < 0)
        {
            rotation.eulerAngles = new Vector3(0f, 0f, 180f);
            spawnOffset.x = -spawnOffset.x;
        }

        Instantiate(runEffectPrefab, transform.position + spawnOffset, rotation);
    }
    
}
