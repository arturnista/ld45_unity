using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthBossAttack : MonoBehaviour
{
    [SerializeField]
    private float attackDamage;
    private EarthBossMovement earthBossMovement;
    private PlayerHealth playerHealth;
    private Rigidbody2D rigidbody2d;

    void Awake()
    {
        earthBossMovement = GetComponent<EarthBossMovement>();
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

        earthBossMovement.enabled = false;
        rigidbody2d.velocity = Vector3.zero;

        yield return new WaitForSeconds(1);

        earthBossMovement.enabled = true;

    }


}
