using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    private CharacterMovemnt characterMovemnt;
    [SerializeField]
    private CharacterAttack characterAttack;

    // Update is called once per frame
    void Update()
    {
        characterMovemnt.MoveCharacter(Input.GetAxis("Horizontal"));
        characterAttack.ChangeDirection(Input.GetAxis("Horizontal"));
        

        if (Input.GetButtonDown("Jump"))
        {
            characterMovemnt.Jump();
        }

        if (Input.GetButtonDown("Fire1")) characterAttack.MeleeAttack();
        if (Input.GetButtonDown("Fire2")) characterAttack.RangedAttack();

    }

    private void FixedUpdate()
    {

    }
}
