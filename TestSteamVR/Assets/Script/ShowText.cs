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
        if (statText != null)
            statText.text = "Win";
        Debug.Log("Win");
    }
    public void ShowLoseText()
    {
      if (statText != null)
            statText.text = "Lose";
      Debug.Log("Lose");   
    }
     public void ShowTryAgainText()
    {
      if (statText != null)
            statText.text = "Please Balance Your Energy.";
      Debug.Log("Balanced");   
    }
    public void ShowSpawnEnemyText()
    {
        if (eventText != null)
            eventText.text = "Bird has arrived!!!";
        Debug.Log("Spawn Bird");
        StartCoroutine(SetSpawnFalse());
    }
    public void ShowSpawnPortal()
    {
        if (eventText != null) 
            eventText.text = "Portal has spawned!!!";
        Debug.Log("Spawn Portal");
        StartCoroutine(SetSpawnFalse());
    }
    IEnumerator SetSpawnFalse()
    {
        yield return new WaitForSeconds(3f);
        eventText.text = "";
    }
}
