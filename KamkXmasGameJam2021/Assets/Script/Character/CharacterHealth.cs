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

    private void Start()
    {
        currentHealth = maxHealth;
    }


    public void TakeDamage(float amount)
    {
        currentHealth -= amount / armour ;
        Debug.Log("damage taken " + amount + ", health left " + currentHealth );
    }
}
