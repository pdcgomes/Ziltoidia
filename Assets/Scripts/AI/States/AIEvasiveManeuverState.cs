using UnityEngine;
using System.Collections;

public class AIEvasiveManeuverState : AIAbstractState
{
    public AIEvasiveManeuverState(EnemyAI entity) : base(entity)
    {
        this.stateID = StateID.EnemyAIEvasiveManeuver;
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

