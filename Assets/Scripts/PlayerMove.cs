using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
	public PlayerData data;
	private float x;
	private float y;
	new Rigidbody2D rigidbody;
	new Collider2D collider;
	private float jumpPressedRememberTime;
	private float groundedRemember;
	private bool grounded;

	private void Start()
	{
		grounded = true;
		rigidbody = GetComponent<Rigidbody2D>();
		collider = GetComponent<Collider2D>();
	}

	void Update()
	{
		float deltaTime = Time.deltaTime;
		x = Input.GetAxis(data.HorizontalAxisName);
		//TODO Less horizontal direction when fall
		//TODO less linear drag when fall

		//TODO analogic jump
		jumpPressedRememberTime -= deltaTime;
		if (Input.GetAxis(data.VerticalAxisName) > 0)
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
		if (!grounded && collision.collider.CompareTag("Plateform")) {
			float v = (transform.position.y + collider.offset.y - ((CapsuleCollider2D)collider).size.y / 3);
			var c = collision.contacts;
			var count = collision.contactCount;
			for (int i = 0; i < count; i++) {
				if (c[i].point.y < v) {
					Debug.Log("I'm grounded." + collision.GetContact(0).point.y);
					grounded = true;
					return;
				}
			}
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (grounded && collision.collider.CompareTag("Plateform")) {
			Debug.Log("I'm no more grounded.");
			grounded = false;
		}

	}
}
