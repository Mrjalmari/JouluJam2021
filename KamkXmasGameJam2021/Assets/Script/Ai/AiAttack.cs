using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiAttack : MonoBehaviour
{
    [SerializeField]
    private float meleeAttackRange = 1;
    [SerializeField]
    private float rangedAttackHeight = 0;

    [SerializeField]
    private float directionMod;

    [SerializeField]
    private CharacterAttack characterAttack;

    // Update is called once per frame
    void Update()
    {
        //directionMod = characterAttack.GetDirection();

        Vector3 direction = Vector3.right * directionMod;

        if(Physics.Raycast(transform.position, direction, out RaycastHit raycastHit))
        {
            float distance = Vector3.Distance(transform.position, raycastHit.point);
            if (raycastHit.collider.CompareTag("Character") && distance < meleeAttackRange)
            {
                characterAttack.ChangeDirection(directionMod);
                characterAttack.MeleeAttack();

            }
            else if (raycastHit.collider.CompareTag("Character"))
            {
                characterAttack.ChangeDirection(directionMod);
                characterAttack.RangedAttack();
            }

        }

    }

    public void ChangeDirection( float newDirection)
    {
        directionMod = newDirection;
    }
}
