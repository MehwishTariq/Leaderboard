using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHandler : MonoBehaviour
{
    #region Mehwishton

    public static DataHandler Instance { get; private set; }
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
    void Start()
    {
        if (LeaderBoard.Instance.players.Count > 0)
        {
            CheckData();
        }
    }
    public void DataUpdate()
    {
        if (LeaderBoard.Instance.players.Count > 0)
        {
            foreach (var item in LeaderBoard.Instance.players)
            {
                item.UpdateData();
            }
        }
       
    }
    public void CheckData()
    {
        foreach (var item in LeaderBoard.Instance.players)
        {
            if (item.CheckFile())
            {
                item.LoadData();
            }
            else
            {
                item.CreateData();
            }
            
        }
    }
    
}
