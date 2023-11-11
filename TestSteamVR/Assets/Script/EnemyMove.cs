using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public Vector3 PlayerPosition;
    public GameObject Player;
    internal int speed = 1;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        MoveToPlayer();
    }

    private void MoveToPlayer()
    {
        PlayerPosition = new Vector3(Player.transform.position.x, 0.5f, Player.transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, PlayerPosition, Time.deltaTime * speed);
        transform.LookAt(Player.transform.position);
    }
}
