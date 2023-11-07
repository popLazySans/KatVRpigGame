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
    public KATDevice kATDevice;
    // Start is called before the first frame update
    void Start()
    {
        kATDevice = GameObject.Find("KAT_Body").GetComponent<KATDevice>();
        updateStartDatatoSlider();
        StartCoroutine(AFK());
    }

    // Update is called once per frame
    void Update()
    {
        updateDatatoText();
        updateDatatoSlider();
        kATDevice.multiply = 1.1f - (Fat / 100);
    }

    private void updateDatatoText()
    {
        pointText.text = "Point : " + Point;
    }

    private void updateStartDatatoSlider()
    {
        energySlider.maxValue = Point*2;
        fatSlider.maxValue = 100;
        vitSlider.maxValue = 100;
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
            yield return new WaitForSeconds(0.1f);
            Point -= 1;
            if (Point == 0)
            {
                SceneManagers sceneManager = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManagers>();
                sceneManager.LoseActive();
            }
        }
        
    }
}
