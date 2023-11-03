using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class TimeCounter : MonoBehaviour
{
    public int time;
    public TMP_Text timeText ;
    public Slider timeSlider;
    // Start is called before the first frame update
    void Start()
    {
        timeSlider.maxValue = time;
        StartCoroutine(timeCount());
    }

    // Update is called once per frame
    void Update()
    {
        timeText.text = "Time : " +time.ToString();
        timeSlider.value = time;
    }
    IEnumerator timeCount()
    {
        while (time>0)
        {
            yield return new WaitForSeconds(1f);
            time -= 1;
        }
        if (time == 0)
        {
            SceneManagers sceneManager = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManagers>();
            sceneManager.LoseActive();
        }

    }
}
