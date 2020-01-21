using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
	public PlayerData data;
	private float x;
	private float y;
	new Rigidbody2D rigidbody;
	new Collider2D collider;
	private float jumpPressedRememberTime;
	private float groundedRemember;
	public GroundCheck GroundCheck;


	private void Start()
	{
		rigidbody = GetComponent<Rigidbody2D>();
		collider = GetComponent<Collider2D>();
	}

	void Update()
	{
		float deltaTime = Time.deltaTime;
		x = Input.GetAxis(data.HorizontalAxisName);
        if(x > 0) { transform.rotation = new Quaternion(0, 0, 0, 0); }

        else if (x < 0) { transform.rotation = new Quaternion(0, 180, 0, 0); }
		//TODO Less horizontal direction when fall
		//TODO less linear drag when fall

		//TODO analogic jump
		#region Jump
		jumpPressedRememberTime -= deltaTime;
		if (Input.GetAxis(data.VerticalAxisName) > 0)
			jumpPressedRememberTime = data.TimeJumpBeforeGrounded;
		
		groundedRemember -= deltaTime;
		if (GroundCheck.IsGrounded) {
			groundedRemember = data.TimeJumpAfterGrounded;
		} else {
			x *= data.AirControlRatio;
		}

		if (jumpPressedRememberTime > 0 && groundedRemember > 0) {
			y = data.jumpForce;
			groundedRemember = 0;
			jumpPressedRememberTime = 0;
		} else
			y = rigidbody.velocity.y;
		#endregion

		#region Crouch

		#endregion

		rigidbody.velocity = (new Vector2(x * data.walkSpeed, y));
	}
}
