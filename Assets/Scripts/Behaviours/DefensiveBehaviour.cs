using UnityEngine;
using UnityEngine.AI;

public class DefensiveBehaviour : FightBehaviour
{
    public Character Execute(NavMeshAgent agent, Character character)
    {
        //The character run towards the nearest ennemy to his king
        Character target = FindNearestEnnemyToKing(character);

        if (target != null)
        {
            agent.SetDestination(target.transform.position);
        }

        return target;
    }

    private Character FindNearestEnnemyToKing(Character character)
    {
        Character kingAlly = GameManager.Instance.kings[character.teamNumber];
        Character nearestEnnemy = null;

        foreach (Character otherCharacter in GameManager.Instance.characters)
        {
            //Filter ennemies
            if (otherCharacter.teamNumber != character.teamNumber)
            {
                if (nearestEnnemy == null)
                {
                    nearestEnnemy = otherCharacter;
                }

                else if (Vector3.Distance(kingAlly.transform.position, otherCharacter.transform.position) <
                Vector3.Distance(kingAlly.transform.position, nearestEnnemy.transform.position))
                {
                    nearestEnnemy = otherCharacter;
                }
            }
        }
        return nearestEnnemy;
    }
}