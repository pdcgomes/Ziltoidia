
using UnityEngine;
using System.Collections;

public class BombCanon : MonoBehaviour
{
    public Rigidbody2D projectile;
    public float projectileSpeed = 1000f;
    public float cooldownDuration = 2f;
    public int ammo = 3;
    public AudioClip fireSound;
    
    private bool readyToFire = true;
    
    void Start()
    {
        audio.clip = fireSound;
    }
    
    void Update()
    {
    }
    
    public void Fire()
    {
        if(!CanFire()) {
            return;
        }
        
        audio.Play();
        Rigidbody2D bullet = (Rigidbody2D)Instantiate(projectile, transform.position, transform.rotation);
        bullet.AddForce(transform.up * projectileSpeed);
        ammo--;
        
        StartWeaponCoolDown();
        
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
    
    private bool CanFire()
    {
        return (readyToFire == true && ammo > 0);
    }
    
}
