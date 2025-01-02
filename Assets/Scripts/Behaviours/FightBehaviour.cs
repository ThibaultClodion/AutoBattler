using UnityEngine.AI;

public interface FightBehaviour
{
    public abstract void Execute(NavMeshAgent agent, Character character);
}