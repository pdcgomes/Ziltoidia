using UnityEngine;
using System.Collections;

public class AIAttackTargetState : AIAbstractState
{
    
    public AIAttackTargetState(EnemyAI entity) : base(entity)
    {
        this.stateID = StateID.EnemyAIAttack;
    }

    public override void DoBeforeEntering()
    {
        base.DoBeforeEntering();
        this.parentEntity.renderer.material.color = Color.red;
    }
    
    public override void DoBeforeLeaving()
    {
        base.DoBeforeLeaving();
    }
    
    public override void Reason()
    {
        
    }
    
    public override void Act()
    {
        this.parentEntity.transform.Translate(Vector3.forward * this.parentEntity.moveSpeed * Time.deltaTime);
    }
}
