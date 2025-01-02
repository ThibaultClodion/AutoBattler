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
    [HideInInspector] public int teamNumber;
    [HideInInspector] public bool isKing;
    [HideInInspector] public Behaviour behaviour;

    [SerializeField] private CharacterData characterData;
    [SerializeField] private NavMeshAgent agent;
    private FightBehaviour fightBehaviour;

    private void Start()
    {
        if (isABot)
        {
            SelfInit(); //Bot can initialize themselves (so it's easy to create levels)
        }
    }

    private void SelfInit()
    {
        GameManager.characters.Add(this);

        //Change his fighting behaviour
        if (behaviour == Behaviour.Neutral)
        {
            Init(teamNumber, new NeutralBehaviour());
        }
        else if (behaviour == Behaviour.Defensive)
        {
            Init(teamNumber, new DefensiveBehaviour());
        }
        else
        {
            Init(teamNumber, new OffensiveBehaviour());
        }

        //Change the king of the team
        if (isKing)
        {
            GameManager.ChangeKing(this);
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