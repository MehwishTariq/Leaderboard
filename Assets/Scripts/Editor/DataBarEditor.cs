using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DataBar))]
public class DataBarEditor : Editor
{
    SerializedProperty Name, Rank, Score;
    DataBar myScript;
    bool showError;

    private void OnEnable()
    {
        myScript = (DataBar)target;
        Name = serializedObject.FindProperty("Name");
        Rank = serializedObject.FindProperty("Rank");
        Score = serializedObject.FindProperty("Score");
    }


    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.ObjectField(Name);
        EditorGUILayout.ObjectField(Rank);
        EditorGUILayout.ObjectField(Score);


        if (GUILayout.Button("CreatePrefab"))
        {
            if (myScript.CheckReferences())
                myScript.CreatePrefabFromGameObject();
            else
                showError = true;
        }

        if(showError)
            EditorGUILayout.HelpBox(myScript.error, MessageType.Error, true);
        serializedObject.ApplyModifiedProperties();
    }

    
}
