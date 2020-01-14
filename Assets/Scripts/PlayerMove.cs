using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
	public PlayerData data;
	private float x;
	private float y;
	new Rigidbody2D rigidbody;
	private float jumpPressedRememberTime;
	private float groundedRemember;
	private bool grounded;
	public AnimationCurve curve;

	private void Start()
	{
		grounded = true;
		rigidbody = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		float deltaTime = Time.deltaTime;
		x = Input.GetAxis(data.HorizontalAxisName);
		//TODO Less horizontal direction when fall
		//TODO less linear drag when fall

		//TODO analogic jump
		jumpPressedRememberTime -= deltaTime;
		if (Input.GetButtonDown("Jump"))
			jumpPressedRememberTime = data.TimeJumpBeforeGrounded;

		groundedRemember -= deltaTime;
		if (grounded) {
			groundedRemember = data.TimeJumpAfterGrounded;
		} else {
			x *= data.AirControlRatio;
		}

		if (jumpPressedRememberTime > 0 && groundedRemember > 0) {
			groundedRemember = 0;
			jumpPressedRememberTime = 0;
			grounded = false;
			y = data.jumpForce;
		} else
			y = rigidbody.velocity.y;

		rigidbody.velocity = new Vector2(x * data.walkSpeed, y);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.CompareTag("Plateform") && collision.GetContact(0).point.y < transform.position.y) {
			Debug.Log("I'm grounded.");
			grounded = true;
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.collider.CompareTag("Plateform") ) {
			Debug.Log("I'm no more grounded.");
			grounded = false;
		}

	}
}
