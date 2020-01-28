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
	public GroundCheck GroundCheck;
	public GrabWallChecker GrabWallChecker;
	public PlayerCrouch PlayerCrouch;

	public bool CanJump { get { return GroundCheck.IsGrounded || (data.CanGrabWall && GrabWallChecker.IsGrabed); } }
	private float canJumpRemember;

	private void Start()
	{
		rigidbody = GetComponent<Rigidbody2D>();
		collider = GetComponent<Collider2D>();
		if (data.CanGrabWall)
			if (GrabWallChecker == null)
				Debug.LogError("Miss GrabWallChecker");
			else
				GrabWallChecker.Controller = this;

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
		
		canJumpRemember -= deltaTime;
		if (CanJump) {
			canJumpRemember = data.TimeJumpAfterGrounded;
		} else {
			//TODO NOT MODIFY VELOCITY IF IS IN DIRECTION OF JUMP
			x *= data.AirControlRatio;
		}

		if (jumpPressedRememberTime > 0 && canJumpRemember > 0) {
			y = data.jumpForce;
			canJumpRemember = 0;
			jumpPressedRememberTime = 0;
		} else
			y = rigidbody.velocity.y;
		#endregion

		#region Crouch

		#endregion

		rigidbody.velocity = (new Vector2(x * data.walkSpeed, y));
	}

	internal void Grab()
	{
		if (data.Crouch && PlayerCrouch.isCrouched)
			return;
		rigidbody.gravityScale = 0;
		if (rigidbody.velocity.y < 0)
			rigidbody.velocity = new Vector2(rigidbody.velocity.x, 0);
	}

	internal void Ungrab()
	{
		//TODO IS DIRTY
		rigidbody.gravityScale = 1.5f;
	}
}
