using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Goal : MonoBehaviour
{
    private GameObject first, second, third;
    [SerializeField]
    private TextMeshProUGUI firstText, secondText, thirdText;


    private void OnTriggerEnter(Collider other)
    {
        if (first == null)
        {
            first = other.gameObject;
            firstText.text = "1." + first.name;
            secondText.text = "2. ---------";
            thirdText.text = "3. ---------";

        }
        else if (second == null)
        {
            second = other.gameObject;
            firstText.text = "1. " + first.name;
            secondText.text = "2. " + second.name;
            thirdText.text = "3. ---------";

        }
        else if (third == null)
        {
            third = other.gameObject;
            firstText.text = "1. " + first.name;
            secondText.text = "2. " + second.name;
            thirdText.text = "3. " + third.name;

        }
    }

        
}
