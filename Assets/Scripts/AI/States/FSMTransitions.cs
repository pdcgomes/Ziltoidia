using System;

/// <summary>
/// Place the labels for the Transitions in this enum.
/// Don't change the first label, NullTransition as FSMSystem class uses it.
/// </summary>
public enum Transition
{
    NullTransition = 0, // Use this transition to represent a non-existing transition in your system
    
    // Enemy AI
    EnemyAITargetInSight,
    EnemyAITargetSightLost,
    EnemyAITargetKilled,
    EnemyAITargetHit,
    EnemyAITargetMiss,
    EnemyAITargetLockAcquired,
    EnemyAITargetLockLost,
    EnemyAIDamageReceived,
}
