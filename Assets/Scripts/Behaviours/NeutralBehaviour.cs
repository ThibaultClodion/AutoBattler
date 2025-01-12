using UnityEngine;
using UnityEngine.AI;

public class NeutralBehaviour : FightBehaviour
{
    public Character Execute(NavMeshAgent agent, Character character)
    {
        //The character run towards the nearest ennemy to attack him
        Character target = FindNearestEnnemy(character);

        if (target != null)
        {
            agent.SetDestination(target.transform.position);
        }

        return target;
    }

    private Character FindNearestEnnemy(Character character)
    {
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

                else if (Vector3.Distance(character.transform.position, otherCharacter.transform.position) <
                Vector3.Distance(character.transform.position, nearestEnnemy.transform.position))
                {
                    nearestEnnemy = otherCharacter;
                }
            }
        }
        return nearestEnnemy;
    }
}