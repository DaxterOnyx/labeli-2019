using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData")]

public class PlayerData : ScriptableObject
{
    public float walkSpeed;
    public float sprintSpeed;
    public string HorizontalAxisName;
    public string VerticalAxisName;
}
