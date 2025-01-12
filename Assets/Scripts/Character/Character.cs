using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public enum MoveBehaviour
{
    Neutral,
    Offensive,
    Defensive
}

public class Character : MonoBehaviour
{
    //Components
    [SerializeField] private CharacterData characterData;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator animator;
    [SerializeField] private Slider hpSlider;
    private MovementBehaviour fightBehaviour;

    //Character's Data
    [HideInInspector] public int teamNumber;  //In case we want to add teams
    private float actualPV;
    private Character target;
    private float spellCooldown;

    [Header("Bot settings")]
    [SerializeField] private bool isABot;
    [SerializeField] public bool isKing;
    [SerializeField] private MoveBehaviour behaviour;


    private void Start()
    {
        //Bots init themselves
        if (isABot)
        {
            //Change his fighting behaviour
            if (behaviour == MoveBehaviour.Neutral)
            {
                GameManager.Instance.CharacterInitialization(this, 1, isKing, new NeutralBehaviour());
            }
            else if (behaviour == MoveBehaviour.Defensive)
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
            StartCoroutine(AttackRoutine());
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

    private IEnumerator AttackRoutine()
    {
        if (target != null && GameManager.Instance.canFight)
        {
            //Can use his spell
            if(spellCooldown <= 0f
                && Vector3.Distance(transform.position, target.transform.position) < characterData.spell.range)
            {
                spellCooldown = characterData.spell.GetCooldownDuration();
                animator.Play("Spell");
                yield return new WaitForSeconds(characterData.spell.GetCooldownDuration());
            }

            //Can use his basic attack
            else if (Vector3.Distance(transform.position, target.transform.position) < characterData.attack.range)
            {
                spellCooldown -= characterData.attack.GetCooldownDuration();
                animator.Play("Attack");
                yield return new WaitForSeconds(characterData.attack.GetCooldownDuration());
            }

            //No target in range (wait)
            else
            {
                spellCooldown -= 1f;
                yield return new WaitForSeconds(1f);
            }
        }
        //Waiting start of game or finding a target
        else
        {
            spellCooldown -= 1f;
            yield return new WaitForSeconds(1f);
        }

        StartCoroutine(AttackRoutine());
    }

    public void Init(int teamNumber, MovementBehaviour fightBehaviour)
    {
        this.teamNumber = teamNumber;
        this.fightBehaviour = fightBehaviour;

        agent.speed = characterData.speed;
        agent.acceleration = characterData.acceleration;
        actualPV = characterData.hp;
        spellCooldown = 0f;
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