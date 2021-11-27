using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    private GameObject owner;
    [SerializeField]
    private float damage = 0.5f;
    private Rigidbody rb;
    [SerializeField]
    private float velocity = 1f;
    private Vector3 directionVelocity;

    [SerializeField]
    private float lifeTime = 2;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject != owner && collision.collider.CompareTag("Character"))
        {
            collision.gameObject.GetComponent<CharacterHealth>().TakeDamage(damage);
        }

        Destroy(gameObject);
    }

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //Vector3 directionVelocity = new Vector3(direction * velocity, 0, 0);
        rb.velocity = directionVelocity;

        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
        else lifeTime -= Time.deltaTime;
    }


    public void SetDirection(float newDirection)
    {
        directionVelocity = new Vector3(newDirection * velocity, 0, 0);
    }

}
