﻿using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData")]

public class PlayerData : ScriptableObject
{
	[Header("General")]
	public int HealthPoints;
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
    public string crouchButton;
	[Header("Punch")]
	//TODO : Punch level and wallbreak
	public bool Punch;
	public Sprite PunchSprite;
	[Header("GrabWall")]
	public bool CanGrabWall;
	[Header("More press more jump.")]
	public float jumpForce;
	public float JumpPressDuration;
	public AnimationCurve JumpHeightCurve;

}
