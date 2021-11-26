using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Aleksi Nieminen 2021, kamk Game jam

public class CharacterMovemnt : MonoBehaviour
{

    [SerializeField]
    public float defaultsSpeed = 2f;
    private float speed;
    private Rigidbody rb;
    private bool isGrounded;
    [SerializeField]
    private float groundDistance = 0.2f;
    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField]
    private float jumpPower;

    // Start is called before the first frame update
    void Start()
    {
        speed = defaultsSpeed;
        rb = gameObject.GetComponent<Rigidbody>();
    }


    private void Update()
    {
        if (Physics.Raycast(transform.position, Vector3.down, groundDistance, groundLayer))
        {
            isGrounded = true;
        }
        else isGrounded = false;
    }


    public void MoveCharacter(float direction)
    {
        float realSpeed = direction * speed* Time.deltaTime;
        Vector3 movemntDirection = (transform.right *realSpeed) + transform.position ;

        rb.position = movemntDirection;


    }

    public void Jump()
    {
        if (isGrounded)
        {
            Vector3 force = new Vector3(0, jumpPower, 0);
            //rb.AddForce(force);
            rb.velocity = force;
        }
    }

}
