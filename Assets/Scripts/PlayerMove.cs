using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public PlayerData data;
    private float x;
    private float y;

    void FixedUpdate()
    {
        x = Input.GetAxis(data.HorizontalAxisName);
        // horizontal movements
        GetComponent<Rigidbody2D>().AddForce(new Vector2 (x * data.walkSpeed, 0));
        //TODO Less horizontal direction when fall
        //TODO less linear drag when fall
        //TODO analogic jump
    }
}
