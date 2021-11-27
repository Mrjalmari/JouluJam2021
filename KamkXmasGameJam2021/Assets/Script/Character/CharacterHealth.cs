using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    private float currentHealth;
    [SerializeField]
    private float maxHealth = 10;

    [SerializeField, Min(1)]
    private float armour = 1;

    [SerializeField]
    private RPGSystem rpgSystem;
    [SerializeField]
    private BasicAIMovemnt basicAIMovemnt;

    private Vector3 respawnLocation;

    private void Start()
    {
        currentHealth = maxHealth;
        SetRespawn(transform.position);
    }


    public float TakeDamage(float amount)
    {
        currentHealth -= amount / armour ;

        if (currentHealth <= 0) Respawn();
        //Debug.Log("damage taken " + amount + ", health left " + currentHealth );
        rpgSystem.HealthLeveling(amount / armour);
        return amount / armour;
    }

    public void IncreaseHealth(float amount)
    {
        maxHealth += amount;
        currentHealth += amount;
    }

    public void RestoreHealth(float amount)
    {
        float tempHealthCalculation = currentHealth + amount;

        if (tempHealthCalculation > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += amount;
        }



    }

    public void SetRespawn(Vector3 location)
    {
        respawnLocation = location;
    }

    public void Respawn()
    {
        currentHealth = maxHealth;
        //Move to respawn location
        transform.position = respawnLocation;

        //if ai active, reset direction
        if(basicAIMovemnt.enabled)
        {
            basicAIMovemnt.ResetDirection();
        }
    }
}
