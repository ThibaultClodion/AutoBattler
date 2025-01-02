using UnityEngine;
using UnityEngine.AI;

public class DefensiveBehaviour : FightBehaviour
{
    public void Execute(NavMeshAgent agent, Character character)
    {
        //The character run towards the nearest ennemy to his king
        Character target = FindNearestEnnemyToKing(character);

        if (target != null)
        {
            agent.SetDestination(target.transform.position);
        }
    }

    private Character FindNearestEnnemyToKing(Character character)
    {
        Character kingAlly = GameManager.kings[character.teamNumber];
        Character nearestEnnemy = null;

        foreach (Character otherCharacter in GameManager.characters)
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