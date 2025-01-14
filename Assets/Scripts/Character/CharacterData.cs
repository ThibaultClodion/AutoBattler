using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "Scriptable Objects/CharacterData")]
public class CharacterData : ScriptableObject
{
    public float hp;
    public float speed;
    public float acceleration;
    public int price;
    public int maxMana;
}