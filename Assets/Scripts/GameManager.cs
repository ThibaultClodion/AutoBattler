using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static List<Character> characters = new List<Character>();
    public static Character[] kings = new Character[2];
    public static bool canFight;

    public static void InstantiateAlly(Character character, Vector3 position, bool isKing)
    {
        Character ally = Instantiate(character, position, Quaternion.identity);
        CharacterInitialization(ally, 0, isKing, new NeutralBehaviour());
    }

    public static void CharacterInitialization(Character character, int teamNumber, bool isKing, FightBehaviour fightBehaviour)
    {
        character.Init(teamNumber, fightBehaviour);
        characters.Add(character);

        if (isKing)
        {
            ChangeKing(character);
        }
    }

    public static void ChangeKing(Character character)
    {
        if (kings[character.teamNumber] != null)
        {
            kings[character.teamNumber].isKing = false;
        }

        kings[character.teamNumber] = character;
        kings[character.teamNumber].isKing = true;
        character.transform.localScale = Vector3.one * 2;   //Todo : change this to a crown over character head
    }

    public static void TweakCanFightValue()
    {
        canFight = !canFight;
    }
}