using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
	public PlayerData data;
	private float x;
	private float y;
	new Rigidbody2D rigidbody;
	private float jumpPressedRememberTime;
	public Vector2 GroundCheckPosition;
	private float groundedRemember;
    public AnimationCurve curve;

	private void Start()
	{

		rigidbody = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate()
	{
		float fixedDeltaTime = Time.fixedDeltaTime;
		x = Input.GetAxis(data.HorizontalAxisName);
		// horizontal movements
		rigidbody.velocity = new Vector2(x * data.walkSpeed, rigidbody.velocity.y);
		//TODO Less horizontal direction when fall
		//TODO less linear drag when fall
	}

	private void Update()
	{
		float fixedDeltaTime = Time.fixedDeltaTime;
		bool grounded = Physics2D.OverlapBox(GroundCheckPosition, transform.localScale, 0, data.PlateformLayer) ;

		//TODO analogic jump
		jumpPressedRememberTime -= fixedDeltaTime;
		if (Input.GetButtonDown("Jump"))
			jumpPressedRememberTime = data.TimeJumpBeforeGrounded;

		groundedRemember -= fixedDeltaTime;
		if (grounded)
			groundedRemember = data.TimeJumpAfterGrounded;

		if (jumpPressedRememberTime > 0 && groundedRemember > 0) {
 			groundedRemember = 0;
			jumpPressedRememberTime = 0;
			rigidbody.velocity = new Vector2(rigidbody.velocity.x, data.jumpForce);
		}
	}

}
