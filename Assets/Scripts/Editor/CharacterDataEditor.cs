using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CharacterData))]
public class CharacterDataEditor : Editor
{
    SerializedProperty characterData, retrievedData;
    CharacterData myScript;

    private void OnEnable()
    {
        myScript = (CharacterData)target;
        characterData = serializedObject.FindProperty("character");
        retrievedData = serializedObject.FindProperty("retrievedData");
    }


    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(characterData, true);
        

        if (GUILayout.Button("SaveData"))
        {
            myScript.SaveData();
        }

        EditorGUILayout.PropertyField(retrievedData, true);

        if (GUILayout.Button("LoadData"))
        {
            myScript.LoadData();
        }
     
        serializedObject.ApplyModifiedProperties();
    }
}
