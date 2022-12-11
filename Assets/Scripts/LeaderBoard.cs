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
   
    public RectTransform dataBarParent;
    public DataBar dataBarPrefab;
     

    [ContextMenu("GenerateDataBar")]
    public void GenerateDataBar()
    {
        players.Sort(SortByScore);

        int rank = 1;
        for (int i = players.Count-1; i >= 0 ; i--)
        {
            //ChangeRank?
            DataBar dataBar = Instantiate(dataBarPrefab, dataBarParent);
            SetData(dataBar, players[i], rank);
            rank++;
        }
    }

    public void SetData(DataBar dataBar,CharacterData c, int rank)
    {
        dataBar.Rank.text = rank.ToString();
        dataBar.Name.text = c.character.name.ToString();
        dataBar.Score.text = c.character.score.ToString();
    }

    static int SortByScore(CharacterData char1, CharacterData char2)
    {
        return char1.character.score.CompareTo(char2.character.score);
    }
}
