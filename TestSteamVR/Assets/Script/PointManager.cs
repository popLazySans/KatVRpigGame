using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class PointManager : MonoBehaviour
{
    public int Point = 0;
    public int Fat = 0;
    public int Vitamin = 0;
    public TMP_Text pointText;
    public Slider energySlider;
    public Slider fatSlider;
    public Slider vitSlider;
    public PlayerSpeedHandler playerSpeedHandler;
    public bool isDesert;
    // Start is called before the first frame update
    void Start()
    {
       
    }
    private void OnEnable()
    {
        updateStartDatatoSlider();
        StartCoroutine(AFK());
        StartCoroutine(TransReduced());
        playerSpeedHandler.speedDelay(Fat);
    }
    // Update is called once per frame
    void Update()
    {
        updateDatatoText();
        updateDatatoSlider();
       
    }

    private void updateDatatoText()
    {
        pointText.text = "Point : " + Point;
    }

    private void updateStartDatatoSlider()
    {
        energySlider.maxValue = Point*2;
        fatSlider.maxValue = 100;
        vitSlider.maxValue = 40;
    }
    private void updateDatatoSlider()
    {
        energySlider.value = Point;
        fatSlider.value = Fat;
        vitSlider.value = Vitamin;
    }

    IEnumerator AFK()
    {
        while (true)
        {
            if (isDesert)
                yield return new WaitForSeconds(0.01f);
            else
                yield return new WaitForSeconds(0.05f);
            Point -= 1;
            if (Point == 0)
            {
                SceneManagers sceneManager = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManagers>();
                sceneManager.LoseActive();
            }
        }
        
    }
    IEnumerator TransReduced()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            if(Fat > 0)
            {
                Fat -= 1;
            }
        }
    }
    public void SetVitaminToZero()
    {
        Vitamin = 0;
    }
    public void OnPointChange(int energy,int fat,int vitamin)
    {
        Point += energy;
        Fat += fat;
        Vitamin += vitamin;
        playerSpeedHandler.speedDelay(Fat);
    }
}
