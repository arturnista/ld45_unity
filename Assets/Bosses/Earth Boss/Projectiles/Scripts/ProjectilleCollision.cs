using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilleCollision : MonoBehaviour
{
    [SerializeField]
    private float attackDamage;

    void Start()
    {

    }

    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        PlayerHealth playerHealth = col.gameObject.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.DealDamage(attackDamage, Vector3.zero);
        }

        Destroy(this.gameObject);
    }
}
