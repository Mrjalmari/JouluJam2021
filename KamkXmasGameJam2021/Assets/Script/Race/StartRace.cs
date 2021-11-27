using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartRace : MonoBehaviour
{
    [SerializeField]
    private List<CharacterMovemnt> characterMovemnts = new List<CharacterMovemnt>();
    [SerializeField]
    private List<CharacterAttack> characterAttacks = new List<CharacterAttack>();


    [SerializeField]
    private float startTimer;
    private float beforeStarting = 2f;
    private float afterStarting = 1f;

    private bool doneStart = false;
    [SerializeField]
    private TextMeshProUGUI timerText;




    private void Update()
    {
        if (beforeStarting > 0) beforeStarting -= Time.deltaTime;
        else if (startTimer >= 0)
        {
            startTimer -= Time.deltaTime;

            timerText.text = "STARTS IN " + (int)startTimer + "!!!";
        }
        else if (!doneStart)
        {

            timerText.text = "GO!!!";
            foreach (var controller in characterMovemnts)
            {
                controller.AllowMovemnt(true);
            }

            foreach (var attack in characterAttacks)
            {
                attack.AllowAttack();
            }
            doneStart = true;
        }
        else if (afterStarting > 0) afterStarting -= Time.deltaTime;
        else timerText.text = "";
    }
}
