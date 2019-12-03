using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayers : MonoBehaviour
{
    public GameObject[] players;
    private Vector3 position;

    private void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    private void FixedUpdate()
    {
        position = new Vector3(0, 0,0);
        foreach (var item in players)
        {
            position += item.transform.position;
        }
        position /= players.Length;

        this.transform.position = new Vector3(position.x, position.y,transform.position.z) ;
    }
}
