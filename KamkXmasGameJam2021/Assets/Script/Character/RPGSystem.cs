using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Aleksi Nieminen 2021

public class RPGSystem : MonoBehaviour
{
    //Speed
    private int speedLevel = 1;
    private float speedXp = 0;
    [SerializeField]
    private float requiredXpSpeed = 1000;
    [SerializeField]
    private float xpPerDistance = 10;
    [SerializeField]
    private float speedIncrease = 2;


    //Jump
    private int jumpLevel = 1;
    private float jumpXp = 0;
    [SerializeField]
    private float requiredXpJump = 100f;
    [SerializeField]
    private float xpPerJump = 10;


    //ranged attack

    private int rangedLevel = 1;
    private float ranged = 0;
    [SerializeField]
    private float requiredXpRanged = 100f;
    [SerializeField]
    private float xpPerRange = 10;
    //Melee attack

    private int meleeLevel = 1;
    private float meleeXp = 0;
    [SerializeField]
    private float requiredXpMelee = 100f;
    [SerializeField]
    private float xpPerMelee = 10;

    //health

    private int healthLevel = 1;
    private float healthXp = 0;
    [SerializeField]
    private float requiredXpHealth = 100f;
    [SerializeField]
    private float xpPerHit = 10;

    //Character Stuff
    [SerializeField]
    private CharacterHealth characterHealth;
    [SerializeField]
    private CharacterAttack characterAttack;
    [SerializeField]
    private CharacterMovemnt characterMovemnt;



    public void SpeedLeveling(float Distance)
    {
        speedXp += Distance * xpPerDistance;

        if(speedXp >= requiredXpSpeed)
        {
            speedLevel++;
            requiredXpSpeed = requiredXpSpeed * speedLevel;
            characterMovemnt.IncreaseSpeed(speedIncrease);
        }

    }

    public void JumpLeveling()
    {
        jumpXp += xpPerJump;
        if (xpPerJump >= requiredXpJump)
        {
            jumpLevel++;
            requiredXpJump = requiredXpJump * jumpLevel;
        }

    }
}
