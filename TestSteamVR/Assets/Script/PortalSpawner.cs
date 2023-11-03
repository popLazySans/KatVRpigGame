using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSpawner : MonoBehaviour
{
    public GameObject portalObject;
    private TimeCounter timeManager;
    // Start is called before the first frame update
    void Start()
    {
        timeManager = GetComponent<TimeCounter>();
        portalObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if it is game.
        if (timeManager.time == 200)
        {
            portalObject.SetActive(true);
        }

        //test
        portalObject.SetActive(true);
    }
}
