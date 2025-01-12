using System.Collections;
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
    //Character's Data
    [HideInInspector] public int teamNumber;  //In case we want to add teams
    private float actualPV;
    private Character target;

    //Components
    [SerializeField] private CharacterData characterData;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator animator;
    [SerializeField] private Slider hpSlider;
    private FightBehaviour fightBehaviour;

    [Header("Bot settings")]
    [SerializeField] private bool isABot;
    [SerializeField] public bool isKing;
    [SerializeField] private Behaviour behaviour;


    private void Start()
    {
        //Bots init themselves
        if (isABot)
        {
            //Change his fighting behaviour
            if (behaviour == Behaviour.Neutral)
            {
                GameManager.Instance.CharacterInitialization(this, 1, isKing, new NeutralBehaviour());
            }
            else if (behaviour == Behaviour.Defensive)
            {
                GameManager.Instance.CharacterInitialization(this, 1, isKing, new DefensiveBehaviour());
            }
            else
            {
                GameManager.Instance.CharacterInitialization(this, 1, isKing, new OffensiveBehaviour());
            }
        }

        if(animator != null)
        {
            StartCoroutine(Attack());
        }
    }

    private void Update()
    {
        if (fightBehaviour != null && GameManager.Instance.canFight)
        {
            target = fightBehaviour.GetTarget(this);

            if (target != null)
            {
                agent.SetDestination(target.transform.position);
            }
        }
    }

    private IEnumerator Attack()
    {
        if(target != null && GameManager.Instance.canFight)
        {
            if (Vector3.Distance(transform.position, target.transform.position) < characterData.attack.range)
            {
                animator.Play("Attack");
            }
        }

        yield return new WaitForSeconds(characterData.attack.GetCooldownDuration());

        StartCoroutine(Attack());
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
            if(isKing)
            {
                GameManager.Instance.EndFight();
            }

            Destroy(gameObject);
        }
    }
}