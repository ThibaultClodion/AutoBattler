using UnityEngine;

public class DefensiveBehaviour : MovementBehaviour
{
    public Character GetTarget(Character character)
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