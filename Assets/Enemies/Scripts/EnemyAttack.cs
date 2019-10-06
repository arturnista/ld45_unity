using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    private float attackDamage;
    EnemyMovement enemyMovement;
    PlayerHealth playerHealth;
    Rigidbody2D rigidbody2d;

    void Awake()
    {
        enemyMovement = GetComponent<EnemyMovement>();
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        playerHealth = col.gameObject.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.DealDamage(attackDamage, transform.position);
            StartCoroutine(FreezeMovement());
        }

    }

    IEnumerator FreezeMovement()
    {

        enemyMovement.enabled = false;
        rigidbody2d.velocity = Vector3.zero;

        yield return new WaitForSeconds(1);

        enemyMovement.enabled = true;

    }
}
