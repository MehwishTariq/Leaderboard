using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class CharacterInfo
{
    public string name;
    //[HideInInspector]
    public int rank { get; set; }
    public float score;
}

[CreateAssetMenu(fileName = "CharacterData", menuName = "Data/Character", order = 1)]
public class CharacterData : ScriptableObject 
{
    [SerializeField]
    public CharacterInfo character;
    public CharacterInfo retrievedData;

    public void SaveData()
    {
        //Create new xml file
        XmlSerializer serializer = new XmlSerializer(typeof(CharacterInfo));            //Create serializer
        FileStream stream = new FileStream(Application.streamingAssetsPath + "/XML/" + character.name, FileMode.Create); //Create file at this path
        serializer.Serialize(stream, character);//Write the data in the xml file
        stream.Close();//Close the stream

    }

    public void LoadData()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(CharacterInfo));            //Create serializer
        FileStream stream = new FileStream(Application.streamingAssetsPath + "/XML/" + character.name, FileMode.Open); //Load file at this path
        retrievedData = serializer.Deserialize(stream) as CharacterInfo;
        stream.Close();//Close the stream

    }

    public void DeleteData()
    {

    }
}
