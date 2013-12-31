using UnityEngine;
using UnityEditor;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
	public Transform target;
	public float distance;
	public float lookAtDistance = 15f;
	public float attackRange = 10f;
	public float moveSpeed = 5f;
	public float damping = 6f;

    private FSMSystem FSM;
    private CircleCollider2D radarCollider;
	
	// Use this for initialization
	void Start()
	{
        SetupStateMachine();
	}

    private void SetupStateMachine()
    {
        
        AIAttackTargetState attackState = new AIAttackTargetState(this);
        AIChaseTargetState chaseState = new AIChaseTargetState(this);
        AIEvasiveManeuverState evasiveManeuverState = new AIEvasiveManeuverState(this);
        AIFleeState fleeState = new AIFleeState(this);
        AIPatrolState patrolState = new AIPatrolState(this);

        patrolState.AddTransition(Transition.EnemyAITargetInSight, StateID.EnemyAIChase);

        chaseState.AddTransition(Transition.EnemyAITargetLockAcquired, StateID.EnemyAIAttack);
        chaseState.AddTransition(Transition.EnemyAITargetSightLost, StateID.EnemyAIPatrol);
//        chaseState.AddTransition(Transition.EnemyAIDamageReceived, StateID.EnemyAIEvasiveManeuver);

        attackState.AddTransition(Transition.EnemyAITargetLockLost, StateID.EnemyAIChase);
        attackState.AddTransition(Transition.EnemyAITargetSightLost, StateID.EnemyAIPatrol);
//        attackState.AddTransition(Transition.EnemyAIDamageReceived, StateID.EnemyAIEvasiveManeuver);

        FSM = new FSMSystem();
        FSM.AddState(patrolState); // Will be the current state (pdcgomes 30.12.2013)
        FSM.AddState(attackState);
        FSM.AddState(chaseState);
        FSM.AddState(evasiveManeuverState);
        FSM.AddState(fleeState);
    }

	// Update is called once per frame
	void Update()
	{
        //Handles.DrawWireDisc(gameObject.transform.position, gameObject.transform.up, 10f);
        if(target != null) {
            Debug.DrawRay(target.transform.position, target.transform.up);
            Debug.DrawLine(transform.position, target.position, Color.white);
        }

//		distance = Vector3.Distance(target.position, transform.position);
//		if(distance < lookAtDistance) {
//				LookAtTarget();
//		}
//		if(distance < attackRange) {
//				//AttackTarget();
//		} 
//		else {
//				renderer.material.color = Color.green;
//		}

        FSM.Update();
	}
	
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player") {
            target = collider.gameObject.transform;
            Debug.Log(string.Format("Collider {0} entered radar", collider.gameObject.tag));
            PerformTransition(Transition.EnemyAITargetInSight);
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player") {
            Debug.Log("Collider exited radar");
            PerformTransition(Transition.EnemyAITargetSightLost);
        }
    }

    void OnTriggerStay2D(Collider2D collider)
    {
//        Debug.Log("Collider inside radar");
//        PerformTransition(Transition.EnemyAITargetInSight);
    }

	void LookAtTarget()
	{
//				transform.rotation = Rotation2D.SmoothLookAt(transform, target.transform.position, target.transform.forward, damping);
		Quaternion rotation = Quaternion.LookRotation(target.position - transform.position, -transform.up);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
		renderer.material.color = Color.yellow;
	}
	
    void ChaseTarget()
    {

    }

    void AttackTarget()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        renderer.material.color = Color.red;
    }

    public void PerformTransition(Transition transition)
    {
        FSM.PerformTransition(transition);
    }
}
