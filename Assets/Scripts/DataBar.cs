using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class DataBar : MonoBehaviour
{
    public Text Name;
    public Text Rank;
    public Text Score;

    public string error {get; set;}

    // Creates a new menu item 'Examples > Create Prefab' in the main menu.
    // [MenuItem("Examples/Create Prefab")]
    public void CreatePrefabFromGameObject()
    {
        // Create folder Prefabs and set the path as within the Prefabs folder,
        // and name it as the GameObject's name with the .Prefab format
        if (!Directory.Exists("Assets/Prefabs"))
            AssetDatabase.CreateFolder("Assets", "Prefabs");
        string localPath = "Assets/Prefabs/" + gameObject.name + ".prefab";

        // Make sure the file name is unique, in case an existing Prefab has the same name.
        localPath = AssetDatabase.GenerateUniqueAssetPath(localPath);

        // Create the new Prefab and log whether Prefab was saved successfully.
        bool prefabSuccess;
        PrefabUtility.SaveAsPrefabAssetAndConnect(gameObject, localPath, InteractionMode.UserAction, out prefabSuccess);

        if (prefabSuccess == true)
            Debug.Log("Prefab was saved successfully");
        else
            Debug.Log("Prefab failed to save" + prefabSuccess);
       
    }

    public bool CheckReferences()
    {
        if (Name == null || Rank == null || Score == null)
        {
            error = "Please Add all References";
            return false;
        }
        return true;
    }
}
