using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
    [SerializeField] private CharacterData characterData;
    [SerializeField] private NavMeshAgent agent;
    
    private int teamNumber;


    public void Init(int teamNumber)
    {
        this.teamNumber = teamNumber;
        agent.speed = characterData.speed;
        agent.acceleration = characterData.acceleration;
    }

    private void Update()
    {
        NeutralBehaviour();
    }

    private void NeutralBehaviour()
    {
        //TODO - modify this to command patterns

        //The character run towards the nearest ennemy to attack him
        agent.SetDestination(FindNearestEnnemyToAPoint(transform.position).transform.position);
    }

    private void OffensiveBehaviour()
    {
        //The character run towards the nearest king to attack him
        agent.SetDestination(FindNearestKing().transform.position);
    }

    private void DefensiveBehaviour()
    {
        //The character run towards the nearest ennemy from his king to attack him
        agent.SetDestination(FindNearestEnnemyToAPoint(GetAllyKing().transform.position).transform.position);
    }

    private Character FindNearestEnnemyToAPoint(Vector3 point)
    {
        Character nearestEnnemy = null;

        foreach(Character character in GameManager.characters)
        {
            //Filter ennemies
            if(character.teamNumber != teamNumber)
            {
                if (nearestEnnemy == null)
                {
                    nearestEnnemy = character;
                }

                else if (Vector3.Distance(point, character.transform.position) <
                Vector3.Distance(point, nearestEnnemy.transform.position))
                {
                    nearestEnnemy = character;
                }
            }
        }
        return nearestEnnemy;
    }

    private Character FindNearestKing()
    {
        Character nearestking = null;

        foreach (Character king in GameManager.kings)
        {
            //Filter ennemies
            if (king.teamNumber != teamNumber)
            {
                if (nearestking == null)
                {
                    nearestking = king;
                }

                else if (Vector3.Distance(transform.position, king.transform.position) <
                Vector3.Distance(transform.position, nearestking.transform.position))
                {
                    nearestking = king;
                }
            }
        }
        return nearestking;
    }

    private Character GetAllyKing()
    {
        return GameManager.kings[teamNumber];
    }
}