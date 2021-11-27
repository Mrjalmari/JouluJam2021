using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Aleksi Nieminen 2021 

public class CharacterAttack : MonoBehaviour
{
    private float directionMod = 1;
    [SerializeField]
    private float attackPointDistance = 1f;
    [SerializeField]
    private float attackpointHeight = 0;
    [SerializeField]
    private float meleeMaxDistance = 2;
    //[SerializeField]
    //private LayerMask characterLayers;
    [SerializeField]
    private float meleeDamage = 1f;
    [SerializeField]
    private GameObject projectile;
    [SerializeField]
    public float rangedDamage = 1;

    [SerializeField]
    private RPGSystem rpgSystem;


    [SerializeField]
    private float rangedWaitTime = 2f;
    private float currentRWTime = 0;
    private bool allowRanged = false;
    [SerializeField]
    private float meleeWaitTime = 1f;
    private float currentMWTime = 0;
    private bool allowMelee = false;

    private void Update()
    {
        if (currentMWTime >= 0)
        {
            currentMWTime -= Time.deltaTime;
        }
        else allowMelee = true;

        if (currentRWTime >= 0) currentRWTime -= Time.deltaTime;
        else allowRanged = true;
    }

    public void ChangeDirection(float newDirection)
    {
        if (newDirection > 0)
        {
            directionMod = 1; 
        }
        else if (newDirection < 0)
        {
            directionMod = -1;
        }
    }


    public void MeleeAttack()
    {
        Vector3 startPoint = new Vector3(transform.position.x + (attackPointDistance* directionMod ), transform.position.y + attackpointHeight ,transform.position.z);

        if(Physics.Raycast(startPoint, Vector3.right*directionMod, out RaycastHit raycastHit, meleeMaxDistance) && allowMelee)
        {
            if (raycastHit.collider.CompareTag("Character"))
            {
               rpgSystem.MeleeAttackLeveling( raycastHit.collider.GetComponent<CharacterHealth>().TakeDamage(meleeDamage));
            }

            allowMelee = false;
            currentMWTime = meleeWaitTime;
        }
    }

    public void RangedAttack()
    {
        if (allowRanged)
        {
            Vector3 startPoint = new Vector3(transform.position.x + (attackPointDistance * directionMod), transform.position.y + attackpointHeight, transform.position.z);
            GameObject projectileInstant = Instantiate(projectile, startPoint, transform.rotation);
            ProjectileScript projectileScript = projectileInstant.GetComponent<ProjectileScript>();
            projectileScript.SetOwner(gameObject);
            projectileScript.SetDirection(directionMod);
            projectileScript.SetDamage(rangedDamage);

            allowRanged = false;
            currentRWTime = rangedWaitTime;
        }

    }

    public void IncreaseRangedDamage(float amount)
    {
        rangedDamage += amount;
    }

    public void IncreaMeleeDamage(float amount)
    {
        meleeDamage += amount;
    }

    public float GetDirection()
    {
        return directionMod;
    }


    public void AllowAttack()
    {
        allowMelee = true;
        allowRanged = true;
    }
}
