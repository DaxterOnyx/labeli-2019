using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouch : MonoBehaviour
{
    private Sprite staySprite;
    private PlayerData data;
    private bool isCrouched;
    private SpriteRenderer sprRender;
    // Start is called before the first frame update
    void Start()
    {
        data = this.GetComponent<PlayerMove>().data;
        //TODO : Animator and no sprite
        staySprite = this.GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        //TODO : Crouch system
        if(data.crouch && Input.GetAxis(data.VerticalAxisName) < 0)
        {
            isCrouched = true;

        }
        else if(isCrouched && Input.GetAxis(data.VerticalAxisName) >= 0)
        {

        }
    }

    private void cutCollider(BoxCollider2D collider)
    {
        collider.size = new Vector2(collider.size.x,(collider.size.y)/2);
        collider.offset = new Vector2(collider.offset.x, collider.size.y / 2);
    }

    private void unCutCollider(BoxCollider2D collider)
    {
        collider.size = new Vector2(collider.size.x, (collider.size.y) *2);
        collider.offset = Vector2.zero;
    }
}
