using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static List<Character> characters = new List<Character>();

    private int numberOfTeam = 2;   //In case we want more teams one day
    public static Character[] kings;

    [SerializeField] private Character allyPrefab;
    [SerializeField] private Character ennemyPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        kings = new Character[numberOfTeam];
        CombatTest();
    }

    private void CombatTest()
    {
        for(int i = 0; i < 10; i++)
        {
            Character blue = Instantiate(allyPrefab, GetRandomVector3(-40,40), Quaternion.identity);
            blue.Init(0);
            characters.Add(blue);

            if(i == 0)
            {
                ChangeKing(blue, 0);
                blue.transform.localScale = Vector3.one * 2;
            }
        }

        for (int i = 0; i < 4; i++)
        {
            Character red = Instantiate(ennemyPrefab, GetRandomVector3(-40, 40), Quaternion.identity);
            red.Init(1);
            characters.Add(red);

            if (i == 0)
            {
                ChangeKing(red, 1);
                red.transform.localScale = Vector3.one * 2;
            }
        }
    }

    private Vector3 GetRandomVector3(float min, float max)
    {
        return new Vector3(Random.Range(min, max), 1, Random.Range(min, max));
    }

    private void ChangeKing(Character character, int teamNumber)
    {
        kings[teamNumber] = character;
    }
}
