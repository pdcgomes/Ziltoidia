using UnityEngine;
using System.Collections;

public class LaserCanon : MonoBehaviour
{
    public Rigidbody2D projectile;
    public float cooldownDuration = 0.01f;
    public float projectileSpeed = 6000f;
    
    private bool readyToFire = true;
    
    void Start()
    {
    }
    
    void Update()
    {
    }
    
    private void StartWeaponCoolDown()
    {
        readyToFire = false;
        Invoke("FinishWeaponCoolDown", cooldownDuration);
    }
    
    private void FinishWeaponCoolDown()
    {
        readyToFire = true;
    }
    
    public void Fire()
    {
        if(readyToFire == false) {
            return;
        }
     
        audio.Play();
          
        Rigidbody2D bullet = (Rigidbody2D)Instantiate(projectile, transform.position, transform.rotation);
        //              projectile.velocity = transform.forward * 300f;
        bullet.AddForce(transform.up * projectileSpeed);
        
        StartWeaponCoolDown();
        
    }
    
}
