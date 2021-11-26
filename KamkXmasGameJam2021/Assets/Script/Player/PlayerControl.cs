using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    private CharacterMovemnt characterMovemnt;

    // Update is called once per frame
    void Update()
    {
        characterMovemnt.MoveCharacter(Input.GetAxis("Horizontal"));


        if (Input.GetButton("Jump"))
        {
            characterMovemnt.Jump();
        }



    }

    private void FixedUpdate()
    {

    }
}
