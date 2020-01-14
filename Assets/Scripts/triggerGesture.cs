using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerGesture : MonoBehaviour
{
    public bool entered;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        entered = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        entered = false;
    }
}
