using UnityEngine;
using System.Collections;

public class ShipControls : MonoBehaviour
{
		public float moveForce = 365f;			// Amount of force added to move the player left and right.
		public float maxSpeed = 5f;				// The fastest the player can travel in the x axis.
		public float turnSpeed = 5f;
		
		private Animator anim;					// Reference to the player's animator component.
		private Bounds bounds;
	
		void Awake()
		{
				anim = GetComponent<Animator>();
		}
	
		// Use this for initialization
		void Start()
		{
				bounds = new Bounds(new Vector3(0, 0, 0), 
									 new Vector3(500, 500));
		}
	
		// Update is called once per frame
		void Update()
		{
		}

		void FixedUpdate()
		{
			float hv = Input.GetAxis("Horizontal");
			float vv = Input.GetAxis("Vertical");

			transform.Translate(0, vv, 0);
			transform.Rotate(0f, 0f, -hv * turnSpeed);
			
	
//			if(hv * rigidbody2D.velocity.x < maxSpeed) {
//                rigidbody2D.AddForce(transform.right * hv * moveForce);
//			}
//
//			if(vv * rigidbody2D.velocity.y < maxSpeed) {
//				rigidbody2D.AddForce(transform.up * vv * moveForce);
//				}
		}
}
		
