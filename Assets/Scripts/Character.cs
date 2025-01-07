using System;
using UnityEngine;
using UnityEngine.AI;

public enum Behaviour
{
    Neutral,
    Offensive,
    Defensive
}

public class Character : MonoBehaviour
{
    //Bot settings
    [HideInInspector] public bool isABot;
    [HideInInspector] public bool isKing;
    [HideInInspector] public Behaviour behaviour;

    [NonSerialized] public int teamNumber;
    [SerializeField] private CharacterData characterData;
    [SerializeField] private NavMeshAgent agent;
    private FightBehaviour fightBehaviour;

    private void Start()
    {
        if (isABot)
        {
            //Change his fighting behaviour
            if (behaviour == Behaviour.Neutral)
            {
                GameManager.CharacterInitialization(this, 1, isKing, new NeutralBehaviour());
            }
            else if (behaviour == Behaviour.Defensive)
            {
                GameManager.CharacterInitialization(this, 1, isKing, new DefensiveBehaviour());
            }
            else
            {
                GameManager.CharacterInitialization(this, 1, isKing, new OffensiveBehaviour());
            }
        }
    }

    public void Init(int teamNumber, FightBehaviour fightBehaviour)
    {
        this.teamNumber = teamNumber;
        this.fightBehaviour = fightBehaviour;

        agent.speed = characterData.speed;
        agent.acceleration = characterData.acceleration;
    }

    private void Update()
    {
        if (fightBehaviour != null)
        {
            fightBehaviour.Execute(agent, this);
        }
    }
}