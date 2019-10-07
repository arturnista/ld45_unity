using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EarthBossHealth : MonoBehaviour
{
    [SerializeField]
    private UnityEvent KillTrigger;
    [SerializeField]
    private float totalHealthPoints;
    private float currentHealthPoints;
    private SpriteRenderer spriteRenderer;
    private EarthBossMovement earthBossMovement;
    private Rigidbody2D rigidbody2d;
    private Color originalColor;
    private Coroutine displayCycleCoroutine;
    private Vector3 enemyPosition;

    void Awake()
    {
        currentHealthPoints = totalHealthPoints;    

        earthBossMovement = GetComponent<EarthBossMovement>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        rigidbody2d = GetComponent<Rigidbody2D>();

        originalColor = spriteRenderer.color;
    }

    void Update()
    {

    }

    public void DealDamage(float attackDamage)
    {
        currentHealthPoints -= attackDamage;

        if (currentHealthPoints <= 0) 
        {          
            KillTrigger.Invoke();
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Earth"))
            {
                go.SetActive(true);
            }
            Destroy(this.gameObject);
        }
        else
        {
            if(displayCycleCoroutine != null) StopCoroutine(displayCycleCoroutine);
            displayCycleCoroutine = StartCoroutine(DamageDisplayCycle());
        }

    }

    IEnumerator DamageDisplayCycle()
    {

        earthBossMovement.enabled = false;
        rigidbody2d.velocity = Vector3.zero;

        for (int i = 0; i < 5; i++)
        {
            if(i % 2 == 0) spriteRenderer.color = Color.white;
            else spriteRenderer.color = originalColor;

            yield return new WaitForSeconds(.1f);
        }
        
        earthBossMovement.enabled = true;
        spriteRenderer.color = originalColor;

        displayCycleCoroutine = null;

    }
}
