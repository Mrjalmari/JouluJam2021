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
    [SerializeField]
    private float jumpIncrease = 1;


    //ranged attack

    private int rangedLevel = 1;
    private float rangedXp = 0;
    [SerializeField]
    private float requiredXpRanged = 100f;
    [SerializeField]
    private float xpPerRange = 10;
    [SerializeField]
    private float RangedDamageIncrease = 1;
    //Melee attack

    private int meleeLevel = 1;
    private float meleeXp = 0;
    [SerializeField]
    private float requiredXpMelee = 100f;
    [SerializeField]
    private float xpPerMelee = 10;
    [SerializeField]
    private float meleeDamageIncrease = 1;

    //health

    private int healthLevel = 1;
    private float healthXp = 0;
    [SerializeField]
    private float requiredXpHealth = 100f;
    [SerializeField]
    private float xpPerHit = 10;
    [SerializeField]
    private float healthPerLevel = 2;

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
            requiredXpSpeed = requiredXpSpeed * (speedLevel * 1.5f);
            characterMovemnt.IncreaseSpeed(speedIncrease);
            Debug.Log("Level up: Speed");
        }

    }

    public void JumpLeveling()
    {
        jumpXp += xpPerJump;
        if (jumpXp >= requiredXpJump)
        {
            jumpLevel++;
            requiredXpJump = requiredXpJump * (jumpLevel * 1.5f);
            characterMovemnt.IncreaseJump(jumpIncrease);
            Debug.Log("Level up: Jump");
        }

    }


    public void RangedAttackLeveling(float dealtDamage)
    {
        rangedXp += dealtDamage * xpPerRange;

        if (rangedXp >= requiredXpRanged)
        {
            rangedLevel++;
            requiredXpRanged = requiredXpRanged * (rangedLevel * 1.5f);
            characterAttack.IncreaseRangedDamage(RangedDamageIncrease);

            Debug.Log("Level up: ranged");
        }
    }

    public void MeleeAttackLeveling(float damageDealt)
    {
        meleeXp += damageDealt * xpPerMelee;
        if (meleeXp >= requiredXpMelee)
        {
            meleeLevel++;
            requiredXpMelee = requiredXpMelee * (meleeLevel * 1.5f);
            characterAttack.IncreaMeleeDamage(meleeDamageIncrease);

            Debug.Log("Level up: melee");
        }
    }

    public void HealthLeveling(float damageTaken)
    {
        healthXp += damageTaken * xpPerHit;
        if (healthXp >= requiredXpHealth)
        {
            healthLevel++;
            requiredXpHealth = requiredXpHealth * (healthLevel * 1.5f);
            characterHealth.IncreaseHealth(healthPerLevel); 
        }
    }
    



}
