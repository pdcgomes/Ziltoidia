using System;

/// <summary>
/// Place the labels for the States in this enum.
/// Don't change the first label, NullTransition as FSMSystem class uses it.
/// </summary>
public enum StateID
{
    NullStateID = 0, // Use this ID to represent a non-existing State in your system    
    
    // Enemy AI
    EnemyAIPatrol,
    EnemyAIChase,
    EnemyAIAttack,
    EnemyAIFlee,
    EnemyAIEvasiveManeuver,
}
