using UnityEngine;
using System.Collections;

public class AIAbstractState : FSMState
{
    protected EnemyAI parentEntity;

    public AIAbstractState(EnemyAI entity) : base()
    {
        parentEntity = entity;
    }
    
    public override void DoBeforeEntering()
    {
        Debug.Log(string.Format("[FSM]: enter state {0}", this.stateID.ToString()));
        this.parentEntity.renderer.material.color = Color.red;
    }
    
    public override void DoBeforeLeaving()
    {
        Debug.Log(string.Format("[FSM]: exit state {0}", this.stateID.ToString()));
    }
    
    public override void Reason()
    {
        
    }
    
    public override void Act()
    {
        
    }
}
