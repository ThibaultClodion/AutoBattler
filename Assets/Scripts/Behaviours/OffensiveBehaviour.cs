using UnityEngine;
using UnityEngine.AI;

public class OffensiveBehaviour : FightBehaviour
{
    public Character Execute(NavMeshAgent agent, Character character)
    {
        //The character run towards the nearest king to attack him
        Character target = FindNearestKing(character);

        if (target != null)
        {
            agent.SetDestination(target.transform.position);
        }

        return target;
    }

    private Character FindNearestKing(Character character)
    {
        Character nearestking = null;

        foreach (Character king in GameManager.Instance.kings)
        {
            //Filter ennemies
            if (king.teamNumber != character.teamNumber)
            {
                if (nearestking == null)
                {
                    nearestking = king;
                }

                else if (Vector3.Distance(character.transform.position, king.transform.position) <
                Vector3.Distance(character.transform.position, nearestking.transform.position))
                {
                    nearestking = king;
                }
            }
        }
        return nearestking;
    }
}