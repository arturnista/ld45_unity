using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private float totalHealthPoints;
    [SerializeField]
    private float stopTime;
    [SerializeField]
    private float impulseForce;
    private float currentHealthPoints;
    private bool isShielded;
    Rigidbody2D rigidbody2d;
    PlayerMovement playerMovement;
    PlayerAttack playerAttack;
    Vector3 playerPosition;
    public float TotalHealthPoints { get { return totalHealthPoints; } }
    public float CurrentHealthPoints { get { return currentHealthPoints; } set { currentHealthPoints = value; } }
    private bool invincible;
    [SerializeField]
    private int invincibleTime;


    void Awake()
    {

        currentHealthPoints = totalHealthPoints;

        playerMovement = GetComponent<PlayerMovement>();
        
        playerAttack = GetComponent<PlayerAttack>();

        rigidbody2d = GetComponent<Rigidbody2D>();

    }

    void Update()
    {

    }

    public void DealDamage(float attackDamage, Vector3 enemyPosition)
    {
        if (!invincible) { 
            currentHealthPoints -= attackDamage;
            StartCoroutine(FreezeMovementAndAttack(enemyPosition));
            StartCoroutine(Invincibility());
        }
        if (currentHealthPoints <= 0) 
        {

            Destroy(this.gameObject);

        }

    }

    IEnumerator Invincibility()
    {
        invincible = true;

        yield return new WaitForSeconds(invincibleTime);

        invincible = false;
    }

    IEnumerator FreezeMovementAndAttack(Vector3 enemyPosition)
    {

        playerPosition = transform.position;
        Vector3 impuseDirection = playerPosition - enemyPosition;
        playerMovement.enabled = false;
        playerAttack.enabled = false;
        rigidbody2d.velocity = Vector3.zero;
        rigidbody2d.AddForce(impuseDirection*impulseForce, ForceMode2D.Impulse);

        yield return new WaitForSeconds(stopTime);

        playerMovement.enabled = true;
        playerAttack.enabled = true;

    }
}
