using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouch : MonoBehaviour
{
    private Sprite staySprite;
    private PlayerData data;
    private bool isCrouched;
    private SpriteRenderer sprRender;
    private BoxCollider2D bCollider;
    public GameObject tester;
    private GameObject testerInstance;
    // Start is called before the first frame update
    void Start()
    {
        testerInstance = Instantiate(tester,this.gameObject.transform);
        bCollider = GetComponent<BoxCollider2D>();
        data = this.GetComponent<PlayerMove>().data;
        //TODO : Animator and no sprite
        sprRender = GetComponent<SpriteRenderer>();
        staySprite = this.GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        //TODO : Crouch system
        if(data.crouch && Input.GetAxis(data.VerticalAxisName) < 0 && !isCrouched)
        {
            isCrouched = true;
            sprRender.sprite = data.crouchSprite;
            cutCollider(bCollider);
        }
        else if(isCrouched && Input.GetAxis(data.VerticalAxisName) >= 0 && !testerInstance.GetComponent<triggerGesture>().entered)
        {
            sprRender.sprite = staySprite;
            unCutCollider(bCollider);
            isCrouched = false;
        }
    }

    private void cutCollider(BoxCollider2D collider)
    {
        collider.size = new Vector2(collider.size.x,(collider.size.y)/2);
        collider.offset = new Vector2(collider.offset.x, - collider.size.y / 2);
    }

    private void unCutCollider(BoxCollider2D collider)
    {
        collider.size = new Vector2(collider.size.x, (collider.size.y) *2);
        collider.offset = Vector2.zero;
    }

}
