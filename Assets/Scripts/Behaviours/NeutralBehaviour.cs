using UnityEngine;

public class NeutralBehaviour : FightBehaviour
{
    public Character GetTarget(Character character)
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