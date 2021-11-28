using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    [SerializeField]
    private Transform generationPoint;

    [SerializeField]
    private GameObject goal;
    [SerializeField]
    private List<GameObject> levelPieces;
    [SerializeField]
    private int levelLenght = 0;


    // Start is called before the first frame update
    void Start()
    {
        int randomIndex = Random.Range(0, levelPieces.Count);

        if (levelLenght >= 0)
        {
            GameObject levelPiece = Instantiate(levelPieces[randomIndex], generationPoint.transform.position, transform.rotation);
            levelPiece.GetComponent<LevelGeneration>().LevelLenghtLess(levelLenght-1);
        }
        else
            Instantiate(goal, generationPoint.transform.position, transform.rotation);




    }

    public void LevelLenghtLess(int newLenght)
    {
        levelLenght = newLenght;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
