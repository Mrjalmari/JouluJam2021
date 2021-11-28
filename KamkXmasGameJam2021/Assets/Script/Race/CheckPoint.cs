using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Aleksi Nieminen 2021
public class CheckPoint : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Character"))
        {
            other.GetComponent<CharacterHealth>().SetRespawn(gameObject.transform.position);
        }
    }


}
