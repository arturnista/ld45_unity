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
    private int attackBornPosition;
    public float Cooldown { get { return cooldown; } set {cooldown = value;}}
    private bool hasAttack;
    public PlayerMovement playerMovement;
    public LayerMask whatIsEnemies;


    void Awake()
    {
        hasAttack = false;
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {

        Vector2 playerPosition = transform.position;
        Vector2 direction = playerMovement.MoveVelocity;
        Vector2 attackPosition = playerPosition + (direction * attackBornPosition);
        Vector3 attackPositionVector3 = attackPosition;

        if (Input.GetKeyDown(KeyCode.Space)) 
        {

            if (hasAttack == false) 
            {

                direction.Normalize();

                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosition, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++) {
                    //enemiesToDamage[i].GetComponent<>().TakeDamage(damage);
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
        Vector2 playerPosition = transform.position;
        Vector2 direction = playerMovement.MoveVelocity;
        Vector3 attackPosition = playerPosition + (direction * attackBornPosition);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPosition, attackRange);
    }

}
