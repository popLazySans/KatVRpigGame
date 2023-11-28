using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSave : MonoBehaviour
{
    private List<int> scoreSaved = new List<int>();
    private ShowText showText;
    //private DistanceToPoint distanceTo;
    // Start is called before the first frame update
    void Start()
    {
        // distanceTo = GameObject.FindGameObjectWithTag("DistancePath").GetComponent<DistanceToPoint>();
        showText = GameObject.FindGameObjectWithTag("ShowText").GetComponent<ShowText>();
        LoadDatatoList();
    }

    // Update is called once per frame
    void Update()
    {
        showText.ShowScoreText(scoreSaved);
    }
    public void SaveCurrentScoreToList(int score)
    {
        scoreSaved.Add(score);
        rankingSet();
        SaveDataToPref();
    }
    public void SaveDataToPref()
    {
        int i = 0;
        string scoreCoding = "";
        foreach (int allscore in scoreSaved)
        {
            i++;
            scoreCoding += allscore+"_";
        }
        PlayerPrefs.SetString("Point", scoreCoding);
    }
    public void LoadDatatoList()
    {
        string[] Data = PlayerPrefs.GetString("Point").Split(char.Parse("_"));
        foreach (string data in Data)
        {
            if(data != "")
            {
                scoreSaved.Add(Convert.ToInt32(data));
                rankingSet();
            }
        }
    }
    public void rankingSet()
    {
        List<int> rankData = new List<int>(scoreSaved.Count);
        foreach (int score in scoreSaved)
        {
            int i = 0;
            foreach (int data in rankData)
            {
                if (score >= data)
                {
                    rankData.Insert(i,score);
                    break;
                }
                i++;
            }
        }
        for(int i=0;i<scoreSaved.Count;i++)
        {
            scoreSaved[i] = rankData[i];
        }
    }
}
