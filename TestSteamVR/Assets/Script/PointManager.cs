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
    public int Vision = 0;
    public TMP_Text pointText;
    public Slider energySlider;
    public Slider fatSlider;
    public Slider vitSlider;
    public PlayerSpeedHandler playerSpeedHandler;
    public bool isDesert;
    private LightUpdate lightPlayer;
    // Start is called before the first frame update
    void Start()
    {
        lightPlayer = GameObject.FindGameObjectWithTag("PlayerLight").GetComponent<LightUpdate>();
    }
    private void OnEnable()
    {
        updateStartDatatoSlider();
        StartCoroutine(AFK());
        StartCoroutine(TransReduced());
        StartCoroutine(lightReduce());
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
    IEnumerator lightReduce()
    {
        yield return new WaitForSeconds(3f);
        if (Vision > 0)
        {
            Vision -= 1;
        }
        lightPlayer.UpdateLight(Vision);
    }
    public void SetVitaminToZero()
    {
        Vitamin = 0;
    }
    public void OnPointChange(int energy,int fat,int vitamin,int vision)
    {
        Point += energy;
        Fat += fat;
        Vitamin += vitamin;
        Vision += vision;
        lightPlayer.UpdateLight(Vision);
        playerSpeedHandler.speedDelay(Fat);
    }
}
