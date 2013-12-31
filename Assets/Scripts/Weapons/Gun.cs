using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{
	public Rigidbody2D projectileNormal;
	public Rigidbody2D projectileCharged;
    public float weaponCooldownDuration = 0.01f;
	public float specialGunChargeTime = 1f;
	public AudioClip gunChargeSound;
	
	private float specialGunChargeLevel = 0f;
    private bool readyToFire = true;

	void Start()
	{
		audio.clip = gunChargeSound;
	}

	void Update()
	{
	}
    
    private void StartWeaponCoolDown()
    {
        readyToFire = false;
        Invoke("FinishWeaponCoolDown", weaponCooldownDuration);
    }
    
    private void FinishWeaponCoolDown()
    {
        readyToFire = true;
    }
	
	public void FireNormalGun()
	{
        if(readyToFire == false) {
            return;
        }
        StartWeaponCoolDown();
        
		Debug.Log("Firing normal projectile!");
		Rigidbody2D projectile = (Rigidbody2D)Instantiate(projectileNormal, transform.position, transform.rotation);
//				projectile.velocity = transform.forward * 300f;
		projectile.AddForce(transform.up * 6000f);
	}
	
	public void ChargeSpecialGun()
	{
		if(specialGunChargeLevel == 0f) {
				audio.Play();
	
		}
		specialGunChargeLevel = Mathf.Clamp(specialGunChargeLevel + Time.deltaTime, 0, specialGunChargeTime);
		Debug.Log(string.Format("Charging gun... Current Charge = {0}", specialGunChargeLevel));
	}
	
	public void FireSpecialGunIfCharged()
	{
		bool canFireGun = (specialGunChargeLevel >= specialGunChargeTime);
		if(canFireGun) {
				Debug.Log("Firing Special Gun!");
				Rigidbody2D projectile = (Rigidbody2D)Instantiate(projectileCharged, transform.position, transform.rotation);
				projectile.AddForce(transform.up * 7000f);
		}

		audio.Stop();
		specialGunChargeLevel = 0;
	}
}
