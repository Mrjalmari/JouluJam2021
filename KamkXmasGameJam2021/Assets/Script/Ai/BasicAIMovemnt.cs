using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Aleksi Nieminen 2021, game jam 

public class BasicAIMovemnt : MonoBehaviour
{
    private int direction = 1;
    private Rigidbody rb;
    private CharacterMovemnt characterMovemnt;

    [SerializeField]
    private float dropCheckDistance;
    [SerializeField]
    private float dropCheckDown;
    [SerializeField]
    private LayerMask groundLayers;
    [SerializeField]
    private LayerMask freefallLayers;
    [SerializeField]
    private float randomJumpChance = 1f;

    [SerializeField]
    private float timeForRandomness = 5f;
    private float currentTFR; //currentTimeForRandomness;


    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        characterMovemnt = gameObject.GetComponent<CharacterMovemnt>();
    }

    // Update is called once per frame
    void Update()
    {

        bool randomJump = false;
        if (currentTFR <= 0)
        {
            randomJump = RandomBool(randomJumpChance);
            currentTFR = timeForRandomness;
        }
        else currentTFR -= Time.deltaTime;
        
        
        if (CheckDrop() || randomJump) 
        {
            characterMovemnt.Jump(); 
        }

        characterMovemnt.MoveCharacter(direction);

    }

    public void ChangeDirection(int newDirection)
    {
        direction = newDirection;
    }


    private bool CheckDrop()
    {
        bool drop = false;
        Vector3 dropCheckPoint = new Vector3(transform.position.x + (dropCheckDistance * direction), transform.position.y, transform.position.z);

        //Debug.DrawRay(dropCheckPoint, Vector3.down, Color.green, dropCheckDown);

        if (Physics.Raycast(dropCheckPoint, Vector3.down, dropCheckDown, groundLayers))
        {
            drop = false;
        }
        else if (Physics.Raycast(dropCheckPoint, Vector3.down, dropCheckDown, freefallLayers))
        {
            drop = false;
        }
        else drop = true;

        return drop;
    }

    private bool CheckObstacle()
    {
        return false;
    }

    private bool RandomBool(float chance)
    {
        bool randBool = false;
        if (Random.Range(0f, 100f) < chance) randBool = true;

            return randBool;
    }
}
