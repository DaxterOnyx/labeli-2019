using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabWall : MonoBehaviour
{
	PlayerData data;
    // Start is called before the first frame update
    void Start()
    {
		data = GetComponentInParent<PlayerController>().data;
    }



}
