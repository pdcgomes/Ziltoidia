using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player") {
            collider.gameObject.GetComponent<PlayerDamageControl>().Hit();
        }
        else if(collider.gameObject.tag == "Enemy") {
        
        }
        //Explode();
        //Destroy(gameObject);
//        rigidbody2D.velocity = Vector2.zero;
    }
    
    void Explode()
    {
        Debug.Log("KABOOOM: implement explosion :)");   
    }
}
    

