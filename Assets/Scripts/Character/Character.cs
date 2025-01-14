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
    [Header("Data")]
    [HideInInspector] public int teamNumber;  //In case we want to add teams
    [SerializeField] private CharacterData characterData;
    [SerializeField] private Attack attack;
    [SerializeField] private Attack spell;
    private int mana;
    private float actualHp;
    private Character target;

    [Header("Components")]
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator animator;
    [SerializeField] private Slider hpSlider;
    [SerializeField] private Slider manaSlider;
    private MovementBehaviour fightBehaviour;

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
            if (mana >= characterData.maxMana
                && Vector3.Distance(transform.position, target.transform.position) < spell.range)
            {
                AddMana(-mana);
                spell.Launch(this, target.transform, animator);
                yield return new WaitForSeconds(spell.GetCooldown());
            }

            //Can use his attack
            else if (Vector3.Distance(transform.position, target.transform.position) < attack.range)
            {
                attack.Launch(this, target.transform, animator);
                yield return new WaitForSeconds(attack.GetCooldown());
            }

            //No target in range (wait)
            else
            {
                yield return new WaitForSeconds(1f);
            }
        }
        //Waiting start of game or finding a target
        else
        {
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
        actualHp = characterData.hp;
        mana = characterData.maxMana;
    }

    public int GetPrice()
    {
        return characterData.price;
    }

    public void AddMana(int amount)
    {
        mana += amount;

        if (mana > characterData.maxMana)
        {
            mana = characterData.maxMana;
        }
        else if(mana < 0)
        {
            mana = 0;
        }

        manaSlider.value = (float)mana / characterData.maxMana;
    }

    public void TakeDamage(float amount)
    {
        actualHp -= amount;

        if (actualHp < 0)
        {
            if (isKing)
            {
                GameManager.Instance.EndFight();
            }

            Destroy(gameObject);
        }
        //Be sure that actualHP is cap
        else if (actualHp > characterData.hp)
        {
            actualHp = characterData.hp;
        }

        hpSlider.value = actualHp / characterData.hp;
    }
}