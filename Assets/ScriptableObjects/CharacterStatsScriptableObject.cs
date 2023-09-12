using UnityEngine;

[CreateAssetMenu(fileName = "CharacterStatsScriptableObject", menuName = "Character Stats")]
public class CharacterStatsScriptableObject : ScriptableObject
{
    [Header("Movement system")]
    public float maxSpeed;
    public float acceleration;
    public float deceleration;

    [Header("Jump sistem")]
    public float jumpForce;
    public float fallMultiplier;
    public float jumpTime;
    public float jumpMultiplier;
    public float jumpDecayPercentage;

    [Header("ChangeSize system")]
    public float mutiplierScale;
    public float changeSizeDuration;
    public float changeSizeCoolDown;
}