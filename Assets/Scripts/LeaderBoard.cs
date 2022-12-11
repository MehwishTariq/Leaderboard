using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class LeaderBoard : MonoBehaviour 
{
    #region Mehwishton

    public static LeaderBoard Instance { get; private set; }
    private void Awake()
    {
     
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    #endregion

    public List<CharacterData> players = new List<CharacterData>();
    [SerializeField]
    List<CharacterData> sorted;
    public RectTransform dataBarParent;
    public DataBar dataBarPrefab;
     void Start()
    {
        
    }
    [ContextMenu("GenerateDataBar")]
    public void GenerateDataBar()
    {
        sorted = null;
        sorted = new List<CharacterData>();
        for (int  i =0;i<players.Count; i++)
        {
            sorted.Add(players[i]);
        }
        
        sorted.Sort(SortByScore);
        for (int i = sorted.Count-1; i >=0 ; i--)
        {
            //ChangeRank?
            DataBar dataBar = Instantiate(dataBarPrefab, dataBarParent);
            SetData(dataBar, sorted[i]);
        }
        //foreach (var item in sorted)
        //{
        //    DataBar dataBar= Instantiate(dataBarPrefab, dataBarParent);
        //    SetData(dataBar,item);
        //}
    }
    public void SetData(DataBar dataBar,CharacterData c)
    {
        dataBar.Rank.text = c.character.rank.ToString();
        dataBar.Name.text = c.character.name.ToString();
        dataBar.Score.text = c.character.score.ToString();
    }

    static int SortByScore(CharacterData char1, CharacterData char2)
    {
        
        return char1.character.score.CompareTo(char2.character.score);
    }
}
