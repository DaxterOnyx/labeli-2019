using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData")]

public class PlayerData : ScriptableObject
{
	public float walkSpeed;
	public float sprintSpeed;
	public string HorizontalAxisName;
	public string VerticalAxisName;
	public float TimeJumpBeforeGrounded;
	public float TimeJumpAfterGrounded;
	public float AirControlRatio;
	[Header("Crouch")]
	public bool Crouch;
	//TODO : Animator and remove Sprite system
	public Sprite CrouchSprite;
	[Header("Punch")]
	//TODO : Punch level and wallbreak
	public bool Punch;
	public Sprite PunchSprite;
	[Header("More press more jump.")]
	public float jumpForce;
	public float JumpPressDuration;
	public AnimationCurve JumpHeightCurve;

}
