using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthBossRangedAttack : MonoBehaviour
{
    [SerializeField]
    private GameObject projectilePrefab;
    [SerializeField]
    private float speed;
    private PlayerMovement playerMovement;

    private bool hasThrowedStone;
    void Start()
    {
        hasThrowedStone = false;
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
    }

    void Update()
    {

        Vector3 bossPosition = transform.position;
        Vector3 playerPosition = playerMovement.transform.position;

        if (!hasThrowedStone)
        {

            StartCoroutine(StoneAttackCooldown());

            Vector2 direction = playerPosition - bossPosition;

            direction.Normalize();

            Vector2 attackSpawnPosition = (Vector2)bossPosition + direction;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            Quaternion rotation = Quaternion.Euler(0f,0f, angle);

            GameObject stoneAttack = Instantiate(projectilePrefab, attackSpawnPosition, rotation);

            Rigidbody2D stoneAttackRigidBody2d = stoneAttack.GetComponent<Rigidbody2D>();

            stoneAttackRigidBody2d.velocity = direction * speed;
            
            hasThrowedStone = true;
            
            StartCoroutine(StoneAttackCooldown());

        }
    }

    IEnumerator StoneAttackCooldown()
    {
        yield return new WaitForSeconds(5);
        hasThrowedStone = false;
    }

}
