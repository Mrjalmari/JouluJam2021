using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Aleksi Nieminen 2021
public class ChangeAiDirection : MonoBehaviour
{

    [SerializeField, Tooltip("1 = Right and -1 = left")]
    private int newDirection = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Character") && other.GetComponent<BasicAIMovemnt>())
        {
            other.GetComponent<BasicAIMovemnt>().ChangeDirection(newDirection);
        }
    }
}
