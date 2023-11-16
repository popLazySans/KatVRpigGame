using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpeedHandler : MonoBehaviour
{
    public KATDevice kATDevice;
    // Start is called before the first frame update
    void Start()
    {
        kATDevice = gameObject.GetComponent<KATDevice>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void speedDelay(float delayValue)
    {
        kATDevice.multiply = 2.1f - (delayValue / 50);
    }
    public void stop()
    {
        kATDevice.multiply = 0;
    }
}
