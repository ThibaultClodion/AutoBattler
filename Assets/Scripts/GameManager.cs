using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static List<Character> characters = new List<Character>();
    public static Character[] kings;

    [SerializeField] private GameObject[] levels;
    [SerializeField] private int numberOfTeam = 2;   //In case we want more teams one day

    void Start()
    {
        kings = new Character[numberOfTeam];

        Instantiate(levels[0]);  //Todo : make the succession of level system
    }

    public static void InstantiateUnit(Character character, Vector3 position, int teamNumber, bool isKing)
    {
        Character unit = Instantiate(character, position, Quaternion.identity);
        unit.Init(teamNumber, new NeutralBehaviour());
        characters.Add(unit);

        if (isKing)
        {
            ChangeKing(unit);
        }
    }

    public static void ChangeKing(Character character)
    {
        kings[character.teamNumber] = character;
        character.transform.localScale = Vector3.one * 2;   //Todo : change this to a crown over character head
    }
}