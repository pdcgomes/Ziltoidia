
using UnityEngine;
using System.Collections;

public class AISweepAreaState : AIAbstractState
{
    private float sweepRadius;
    
    public AISweepAreaState(EnemyAI entity) : base(entity)
    {
        this.stateID = StateID.EnemyAISweepArea;
    }
    
    public override void DoBeforeEntering()
    {
        base.DoBeforeEntering();
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
        
    }
}
