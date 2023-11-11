using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public PointManager pointManager;
    private EnemyMove enemyMove;
    private SceneManagers sceneManagers;
    // Start is called before the first frame update
    void Start()
    {
        enemyMove = gameObject.GetComponent<EnemyMove>();
        sceneManagers = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManagers>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (pointManager.Vitamin >= 100)
            {
                pointManager.SetVitaminToZero();
                Stunned();
            }
            else
            {
                gameObject.SetActive(false);
                sceneManagers.LoseActive();
            }
        }
    }
    public void Stunned()
    {
        enemyMove.speed = 0;
        StartCoroutine(Recovering());
    }
    IEnumerator Recovering()
    {
        yield return new WaitForSeconds(5);
        enemyMove.speed = 10;
    }
}
