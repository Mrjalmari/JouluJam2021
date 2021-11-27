using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Aleksi Nieminen 2021, kamk Game jam

public class CharacterMovemnt : MonoBehaviour
{

    [SerializeField]
    public float defaultsSpeed = 2f;
    private float speed = 10;
    private Rigidbody rb;
    private bool isGrounded;
    [SerializeField]
    private float groundDistance = 0.2f;
    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField]
    private float jumpPower;

    [SerializeField]
    private RPGSystem rpgSystem;
    [SerializeField]
    private CharacterHealth characterHealth;
    [SerializeField]
    private float minY = -10f;

    [SerializeField]
    private bool allowMoving = false;

    private Vector3 previousPoint;

    // Start is called before the first frame update
    void Start()
    {
        speed = defaultsSpeed;
        rb = gameObject.GetComponent<Rigidbody>();
        previousPoint = transform.position;
    }


    private void Update()
    {
        if (Physics.Raycast(transform.position, Vector3.down, groundDistance, groundLayer))
        {
            isGrounded = true;
        }
        else isGrounded = false;

        if (transform.position.y < minY) characterHealth.Respawn();
    }


    public void MoveCharacter(float direction)
    {
        if (allowMoving)
        {
            float realSpeed = direction * speed * Time.deltaTime;
            Vector3 movemntDirection = (transform.right * realSpeed) + transform.position;

            rb.position = movemntDirection;

            float distance = Vector3.Distance(previousPoint, transform.position);
            rpgSystem.SpeedLeveling(distance);
            previousPoint = transform.position;

        }


    }

    public void Jump()
    {
        if (isGrounded && allowMoving)
        {
            Vector3 force = new Vector3(0, jumpPower, 0);
            //rb.AddForce(force);
            rb.velocity = force;
            rpgSystem.JumpLeveling();
        }
    }

    public void IncreaseSpeed(float amount)
    {
        speed += amount;
    }

    public void IncreaseJump(float amount)
    {
        jumpPower += amount;
    }

    public void AllowMovemnt(bool allow)
    {
        allowMoving = allow;
    }

}
