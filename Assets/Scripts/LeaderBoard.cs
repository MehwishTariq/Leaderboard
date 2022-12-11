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

    public List<DataBar> dataBars = new List<DataBar>();
    public RectTransform dataBarParent;
    public DataBar dataBarPrefab;
    void Start()
    {
        
    }

    [ContextMenu("RandomPlayerWon")]
    public void RandomPlayerWon()
    {
        int x = Random.Range(0, players.Count);
        Debug.Log("Winer:"+ players[x].character.name);
        players[x].character.score += Random.Range(50, 100);
        for (int i = 0; i < players.Count; i++)
        {
            if(i!=x)
                players[i].character.score += Random.Range(20, 50);
        }
        GenerateDataBar();
    }
    public void GenerateDataBar()
    {
        for (int i = 0; i < dataBars.Count; i++)
        {
            Destroy(dataBars[i].gameObject);

        }
        
        dataBars.Clear();
        sorted.Clear();
        sorted = new List<CharacterData>();
        for (int  i =0;i<players.Count; i++)
        {
            sorted.Add(players[i]);
        }
        
        sorted.Sort(SortByScore);
        int rank = 1;
        for (int i = sorted.Count-1; i >=0 ; i--)
        {  
            sorted[i].character.rank = rank;
            DataBar dataBar = Instantiate(dataBarPrefab, dataBarParent);
            dataBars.Add(dataBar);
            SetData(dataBar, sorted[i]);
            rank++;
        }
        DataHandler.Instance.DataUpdate();

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
