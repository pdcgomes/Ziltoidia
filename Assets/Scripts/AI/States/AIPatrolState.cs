using UnityEngine;
using System.Collections;

public class AIPatrolState : AIAbstractState
{
    private Vector3[] patrolAlongPath;
    private float patrolDistance = 10f;
    private float pathPosition = 0;
    
    public AIPatrolState(EnemyAI entity) : base(entity)
    {
        this.stateID = StateID.EnemyAIPatrol;
    }
    
    public override void DoBeforeEntering()
    {
        base.DoBeforeEntering();
        GenerateRandomPatrolPath();
        this.parentEntity.rigidbody2D.velocity = Vector2.zero;
    }
    
    public override void DoBeforeLeaving()
    {
        base.DoBeforeLeaving();        
    }
    
    public override void Reason()
    {
//        if(this.pathPosition == this.patrolAlongPath.Length) {
//            this.pathPosition = 0;
//        }   
    }
    
    public override void Act()
    {
        this.parentEntity.renderer.material.color = Color.green;
//        this.parentEntity.transform.LookAt(this.patrolAlongPath[(int)this.pathPosition]);
        this.parentEntity.transform.position = Spline.MoveOnPath(patrolAlongPath, this.parentEntity.transform.position, ref pathPosition, 5f);
    }
    
    private void GenerateRandomPatrolPath()
    {
        Vector3 center = this.parentEntity.transform.position;
        this.patrolAlongPath = new []{ 
            new Vector3(center.x - this.patrolDistance, center.y + this.patrolDistance, 0),
            new Vector3(center.x + this.patrolDistance, center.y + this.patrolDistance, 0), 
            new Vector3(center.x + this.patrolDistance, center.y - this.patrolDistance, 0),
            new Vector3(center.x - this.patrolDistance, center.y - this.patrolDistance, 0)};
    }
}
