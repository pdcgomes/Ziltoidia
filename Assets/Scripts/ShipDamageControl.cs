using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShipDamageControl : MonoBehaviour
{
    public delegate void ShipDestroyedDelegate();
    public event ShipDestroyedDelegate OnShipDestroyed;
    
    public float health = 100f;                 // The player's health.
    public float damagePerHit = 10f;            // The amount of damage to take when enemies touch the player
    
    private Vector3 healthScale;                // The local scale of the health bar initially (with full health).
    private SortedDictionary<float, string> damageLevels;
    
    void Awake()
    {
        damageLevels = new SortedDictionary<float, string>();
        damageLevels.Add( 5f, "critical");
        damageLevels.Add(15f, "severe");
        damageLevels.Add(35f, "serious");
        damageLevels.Add(50f, "not good");
        damageLevels.Add(75f, "okay");
    }
	// Use this for initialization
	void Start()
    {
	
	}
	
    public void Hit()
    {
        TakeDamage();
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(string.Format("Damage taken. Health = {0}", health));
        
        if(collision.gameObject.tag == "Bullet") {
            TakeDamage();
        }
    }
    
    void TakeDamage()
    {
        ApplyDamage();
        UpdateHealthBar();
        UpdateAppearanceForCurrentDamage();
    }
    
    void ApplyDamage()
    {
        if(health <= 0f) {
            return;
        }
        
        health -= damagePerHit;
        Debug.Log(string.Format("Damage taken. Health = {0}", health));
        if(health <= 0) {
           Die();  
        }
    }
    
    void UpdateHealthBar()
    {
        // Set the health bar's colour to proportion of the way between green and red based on the player's health.
//        healthBar.material.color = Color.Lerp(Color.green, Color.red, 1 - health * 0.01f);
        
        // Set the scale of the health bar to be proportional to the player's health.
//        healthBar.transform.localScale = new Vector3(healthScale.x * health * 0.01f, 1, 1);
    }
    
    void UpdateAppearanceForCurrentDamage()
    {
        
        foreach(KeyValuePair<float, string> level in damageLevels) {
            if(level.Key > health) {
                break;
            }    
            // apply appearance here   
        }
    }
    
    void Die()
    {
        if(OnShipDestroyed != null) OnShipDestroyed();
        Destroy(gameObject);
    }
}
