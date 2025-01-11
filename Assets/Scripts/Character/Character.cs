using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

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
    [HideInInspector] public Behaviour behaviour;

    //Character's Data
    [HideInInspector] public int teamNumber;  //In case we want to add teams
    [HideInInspector] public bool isKing;
    private float actualPV;

    //Components
    [SerializeField] private CharacterData characterData;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Slider hpSlider;
    private FightBehaviour fightBehaviour;

    private void Start()
    {
        //Bots init themselves
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

    private void Update()
    {
        if (fightBehaviour != null && GameManager.canFight)
        {
            fightBehaviour.Execute(agent, this);
        }
    }

    public void Init(int teamNumber, FightBehaviour fightBehaviour)
    {
        this.teamNumber = teamNumber;
        this.fightBehaviour = fightBehaviour;

        agent.speed = characterData.speed;
        agent.acceleration = characterData.acceleration;
        actualPV = characterData.hp;
    }

    public int GetPrice()
    {
        return characterData.price;
    }

    public void TakeDamage(float amount)
    {
        actualPV -= amount;
        hpSlider.value = actualPV / characterData.hp;

        if(actualPV < 0)
        {
            //TODO - Check if it's king and end game if it is the case

            Destroy(gameObject);
        }
    }
}