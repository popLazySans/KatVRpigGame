using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ShowText : MonoBehaviour
{
    public TMP_Text statText;
    public TMP_Text eventText;

    public void ShowWinText()
    {
        if (eventText != null)
            eventText.text = "Win";
        Debug.Log("Win");
    }
    public void ShowLoseText()
    {
      if (eventText != null)
            eventText.text = "Lose";
      Debug.Log("Lose");   
    }
    public void ShowSpawnEnemyText()
    {
        if (statText != null)
            statText.text = "Bird has arrived!!!";
        Debug.Log("Spawn Bird");
        StartCoroutine(SetSpawnFalse());
    }
    public void ShowSpawnPortal()
    {
        if (statText != null) 
            statText.text = "Portal has spawned!!!";
        Debug.Log("Spawn Portal");
        StartCoroutine(SetSpawnFalse());
    }
    IEnumerator SetSpawnFalse()
    {
        yield return new WaitForSeconds(3f);
        statText.text = "";
    }
}
