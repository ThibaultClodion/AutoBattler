using UnityEngine.AI;

public interface FightBehaviour
{
    public abstract Character Execute(NavMeshAgent agent, Character character);
}