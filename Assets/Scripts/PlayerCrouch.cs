using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouch : MonoBehaviour
{
    private Sprite staySprite;
    private PlayerData data;
    private bool isCrouched;
    private SpriteRenderer sprRender;
    private CapsuleCollider2D bCollider;
    public GameObject tester;
    private GameObject testerInstance;
    public float crouched_collider_size;
    private float stand_collider_size;
    public float crouched_collider_offset;
    private float stand_collider_offset;
    // Start is called before the first frame update
    void Start()
    {
        testerInstance = Instantiate(tester,this.gameObject.transform);
        bCollider = GetComponent<CapsuleCollider2D>();
        stand_collider_size = bCollider.size.y;
        stand_collider_offset = bCollider.offset.y;
        data = this.GetComponent<PlayerMove>().data;
        //TODO : Animator and no sprite
        sprRender = GetComponent<SpriteRenderer>();
        staySprite = this.GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        //TODO : Crouch system
        if(data.Crouch && Input.GetAxis(data.VerticalAxisName) < 0 && !isCrouched)
        {
            isCrouched = true;
            sprRender.sprite = data.CrouchSprite;
            cutCollider(bCollider);
        }
        else if(isCrouched && Input.GetAxis(data.VerticalAxisName) >= 0 && !testerInstance.GetComponent<triggerGesture>().entered)
        {
            sprRender.sprite = staySprite;
            unCutCollider(bCollider);
            isCrouched = false;
        }
    }

    private void cutCollider(CapsuleCollider2D collider)
    {
        collider.size = new Vector2(collider.size.x,crouched_collider_size);
        collider.offset = new Vector2(collider.offset.x, crouched_collider_offset);
    }

    private void unCutCollider(CapsuleCollider2D collider)
    {
        collider.size = new Vector2(collider.size.x, stand_collider_size);
        collider.offset = new Vector2(collider.offset.x, stand_collider_offset);
    }

}
