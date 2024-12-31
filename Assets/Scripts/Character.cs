using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
    [SerializeField] private CharacterData characterData;
    [SerializeField] private NavMeshAgent agent;

    private GameObject ennemy;

    private void Awake()
    {
        agent.speed = characterData.speed;
        agent.acceleration = characterData.acceleration;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(gameObject.tag == "Ally")
        {
            ennemy = GameObject.FindGameObjectWithTag("Ennemy");
        }
        else if(gameObject.tag == "Ennemy")
        {
            ennemy = GameObject.FindGameObjectWithTag("Ally");
        }

    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(ennemy.transform.position);
    }
}
