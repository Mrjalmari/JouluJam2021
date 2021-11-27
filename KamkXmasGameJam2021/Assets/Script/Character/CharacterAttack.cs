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

        if(Physics.Raycast(startPoint, Vector3.right*directionMod, out RaycastHit raycastHit, meleeMaxDistance))
        {
            if (raycastHit.collider.CompareTag("Character"))
            {
                raycastHit.collider.GetComponent<CharacterHealth>().TakeDamage(meleeDamage);
            }
        }
    }

    public void RangedAttack()
    {
        Vector3 startPoint = new Vector3(transform.position.x + (attackPointDistance * directionMod), transform.position.y + attackpointHeight, transform.position.z);
        GameObject projectileInstant = Instantiate(projectile, startPoint, transform.rotation);
        projectileInstant.GetComponent<ProjectileScript>().SetDirection(directionMod);
    }
}
