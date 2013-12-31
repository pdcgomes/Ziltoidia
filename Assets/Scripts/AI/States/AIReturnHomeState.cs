using UnityEngine;
using System.Collections;

public class AIReturnHomeState : AIAbstractState
{
    public AIReturnHomeState(EnemyAI entity) : base(entity)
    {
        this.stateID = StateID.EnemyAIReturnHome;
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
