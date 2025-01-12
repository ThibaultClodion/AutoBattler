using UnityEngine;

public class OffensiveBehaviour : FightBehaviour
{
    public Character GetTarget(Character character)
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