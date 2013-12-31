using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        // FIXME: I'm sure this can be solved differently
        // Right now we're doing this to prevent 'radar' colliders from triggering this event
        // For example, an enemy specifies a large radius for its radar, when it fires, the projectile
        // triggers this event, and we want to ignore it (pdcgomes 31.12.2013)
        if(collider.isTrigger) {
            return;
        }
        
        Debug.Log(string.Format("[PROJECTILE] OnTriggerEnter2D for {0}", collider.gameObject.name));
        if(collider.gameObject.tag == "Player") {
            // TODO: maybe define the damage we want to apply here?
            // (pdcgomes 31.12.2013)
            collider.gameObject.GetComponent<ShipDamageControl>().Hit();
        }
        else if(collider.gameObject.tag == "Enemy") {
            collider.gameObject.GetComponent<ShipDamageControl>().Hit();
        }
        Explode();
        //Destroy(gameObject);
//        rigidbody2D.velocity = Vector2.zero;
    }
    
    void Explode()
    {
        Debug.Log("KABOOOM: implement explosion :)");   
    }
}
    

