using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [NonSerialized] public List<Character> characters = new List<Character>();
    [NonSerialized] public Character[] kings = new Character[2];
    [NonSerialized] public bool canFight;

    [SerializeField] private GameObject endPopup;
    [SerializeField] private TextMeshProUGUI endText;

    public void InstantiateAlly(Character character, Vector3 position, bool isKing)
    {
        Character ally = Instantiate(character, position, Quaternion.identity);
        CharacterInitialization(ally, 0, isKing, new NeutralBehaviour());
    }

    public void CharacterInitialization(Character character, int teamNumber, bool isKing, MovementBehaviour fightBehaviour)
    {
        character.Init(teamNumber, fightBehaviour);
        characters.Add(character);

        if(isKing)
        {
            ChangeKing(character);
        }
    }

    public void ChangeKing(Character character)
    {
        if(kings[character.teamNumber] != null)
        {
            kings[character.teamNumber].IsKing(false);
        }

        kings[character.teamNumber] = character;
        kings[character.teamNumber].IsKing(true);
    }

    //Useful to start the game and let unit move
    public void TweakCanFightValue()
    {
        canFight = !canFight;
    }

    public void EndFight(int teamNumber)
    {
        if(teamNumber == 0)
        {
            endText.text = "You Lose !";
        }
        else
        {
            endText.text = "You Win !";
        }

        canFight = false;
        endPopup.SetActive(true);
    }
}