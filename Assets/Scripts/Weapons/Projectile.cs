using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player") {
            // TODO: maybe define the damage we want to apply here?
            // (pdcgomes 31.12.2013)
            collider.gameObject.GetComponent<PlayerDamageControl>().Hit();
        }
        else if(collider.gameObject.tag == "Enemy") {
            collider.gameObject.GetComponent<ShipDamageControl>().Hit();
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
    

