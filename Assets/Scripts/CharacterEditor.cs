#if UNITY_EDITOR
using UnityEditor;

[CustomEditor(typeof(Character))]
public class CharacterEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        Character characterScript = (Character)target;

        // Toogle to know if the character is a bot
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Bot Settings", EditorStyles.boldLabel);
        characterScript.isABot = EditorGUILayout.Toggle("Is a Bot ?", characterScript.isABot);

        if (characterScript.isABot) // if is a bot, show other fields
        {
            characterScript.teamNumber = EditorGUILayout.IntField("Team Number", characterScript.teamNumber);
            characterScript.isKing = EditorGUILayout.Toggle("Is a King ?", characterScript.isKing);
            characterScript.behaviour = (Behaviour) EditorGUILayout.EnumPopup("Fighting Behaviour", characterScript.behaviour);
        }
    }
}
#endif