using UnityEngine;
using System.Collections;

public class AIChaseTargetState : AIAbstractState
{
    private LaserCanon weapon;
    
    public AIChaseTargetState (EnemyAI entity) : base(entity)
    {
        this.stateID = StateID.EnemyAIChase;        
        this.weapon = this.parentEntity.GetComponentInChildren<LaserCanon>();
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
        Vector3 distanceToTarget = this.parentEntity.target.position - this.parentEntity.transform.position;
        Quaternion rotation = Quaternion.LookRotation(distanceToTarget, 
                                                      -this.parentEntity.transform.forward);
        this.parentEntity.transform.rotation = Quaternion.Slerp(this.parentEntity.transform.rotation, rotation, 
                                                                Time.deltaTime * this.parentEntity.damping);
        this.parentEntity.transform.eulerAngles = new Vector3(0, 0, this.parentEntity.transform.eulerAngles.z);
        
        this.parentEntity.rigidbody2D.velocity = new Vector2(distanceToTarget.x, distanceToTarget.y);
        this.parentEntity.renderer.material.color = Color.yellow;
        
        this.weapon.Fire();
    }
}

