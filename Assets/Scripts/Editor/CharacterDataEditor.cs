using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CharacterData))]
public class CharacterDataEditor : Editor
{
    SerializedProperty characterData;
    CharacterData myScript;

    private void OnEnable()
    {
        myScript = (CharacterData)target;
        characterData = serializedObject.FindProperty("character");
      
    }


    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(characterData, true);
        

        if (GUILayout.Button("SaveData"))
        {
            myScript.CreateData();
        }


        if (GUILayout.Button("LoadData"))
        {
            myScript.LoadData();
        }
     
        serializedObject.ApplyModifiedProperties();
    }
}
