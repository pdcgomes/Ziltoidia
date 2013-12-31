using UnityEngine;
using System.Collections;

public class AIFleeState : AIAbstractState
{
    public AIFleeState(EnemyAI entity) : base(entity)
    {
        this.stateID = StateID.EnemyAIFlee;
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
