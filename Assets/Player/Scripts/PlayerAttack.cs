using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private GameObject attackPrefab;
    [SerializeField]
    private float cooldown = 0.5f;
    [SerializeField]
    private int damage;
    [SerializeField]
    private float attackRange;
    [SerializeField]
    private float attackBornPosition;
    public float Cooldown { get { return cooldown; } set {cooldown = value;}}
    private bool hasAttack;
    public PlayerMovement playerMovement;
    public LayerMask whatIsEnemies;
    public LayerMask whatIsBoss;


    void Awake()
    {
        hasAttack = false;
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {

        Vector2 playerPosition = transform.position;
        Vector2 direction = playerMovement.LookDirection;
        Vector2 attackPosition = playerPosition + (direction * attackBornPosition);
        Vector3 attackPositionVector3 = attackPosition;

        if (Input.GetKeyDown(KeyCode.Space)) 
        {

            if (hasAttack == false) 
            {
                direction.Normalize();

                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosition, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++) 
                {
                    enemiesToDamage[i].GetComponent<EnemyHealth>().DealDamage(damage);
                    enemiesToDamage[i].GetComponent<EarthBossHealth>().DealDamage(damage);

                }

                Collider2D[] bossesToDamage = Physics2D.OverlapCircleAll(attackPosition, attackRange, whatIsBoss);
                for (int i = 0; i < bossesToDamage.Length; i++) 
                {
                    bossesToDamage[i].GetComponent<EarthBossHealth>().DealDamage(damage);
                }

                StartCoroutine(AttackCooldown());
                
            }

        }

    }

    IEnumerator AttackCooldown() 
    {
        hasAttack = true;

        yield return new WaitForSeconds(cooldown);

        hasAttack = false;
    }

    void OnDrawGizmos()
    {
        if(playerMovement == null) playerMovement = GetComponent<PlayerMovement>();
        Vector2 playerPosition = transform.position;
        Vector2 direction = playerMovement.LookDirection;
        if(direction == Vector2.zero) direction = Vector2.one;
        Vector3 attackPosition = playerPosition + (direction * attackBornPosition);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPosition, attackRange);
    }

}
