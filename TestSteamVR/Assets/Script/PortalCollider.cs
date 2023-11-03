using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
        
            SceneManagers sceneManager = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManagers>();
            
            //test
            sceneManager.WinActive();
            sceneManager.clickToAnotherScene("Play");
            return;
            PointManager pointManager = GameObject.FindGameObjectWithTag("PointManager").GetComponent<PointManager>();
            if (pointManager != null)
            {
                if (pointManager.Point >= 1500 && pointManager.Point <= 2500 && pointManager.Vitamin == 100)
                {
                    sceneManager.WinActive();
                    sceneManager.clickToAnotherScene("Play");
                    Destroy(this.gameObject);
                }
                else
                {
                    sceneManager.TryAgain();
                }
            }

            
        }
    }
}
