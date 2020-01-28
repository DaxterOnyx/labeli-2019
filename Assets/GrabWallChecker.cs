using UnityEngine;

public class GrabWallChecker : MonoBehaviour
{
	public bool IsGrabed { get; private set; }

	public PlayerController Controller;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (!IsGrabed) {
			Controller.Grab();
			IsGrabed = true;
		}
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (!IsGrabed) {
			Controller.Grab();
			IsGrabed = true;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (IsGrabed) {
			Controller.Ungrab();
			IsGrabed = false;
		}
	}

}
