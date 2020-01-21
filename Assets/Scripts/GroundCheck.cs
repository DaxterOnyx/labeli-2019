using UnityEngine;
[RequireComponent(typeof(Collider2D))]
public class GroundCheck : MonoBehaviour
{
	public bool IsGrounded { get; private set; }
	public Collider2D TriggerGroundCheck;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		IsGrounded = true;
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		IsGrounded = true;
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		IsGrounded = false;
	}
}