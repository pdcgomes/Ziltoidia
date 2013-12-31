using UnityEngine;
using System.Collections;

public class PulseChargeCanon : MonoBehaviour
{
    public Rigidbody2D projectile;
    public float chargingDuration = 1f;
    public AudioClip chargingSound;
    public AudioClip fireSound;
    
    private float chargeLevel = 0f;
    private bool readyToFire = true;
    
    void Start()
    {
        audio.clip = chargingSound;
    }
    
    void Update()
    {
    }
    
    public void Charge()
    {
        if(chargeLevel == 0f) {
            audio.clip = chargingSound;
            audio.Play();
        }
        chargeLevel = Mathf.Clamp(chargeLevel + Time.deltaTime, 0, chargingDuration);
        Debug.Log(string.Format("Charging canon... {0}%", chargeLevel/chargingDuration * 100f));
        readyToFire = (chargeLevel >= chargingDuration);
    }
    
    public void Fire()
    {
        audio.Stop();
        
        if(readyToFire) {
            audio.clip = fireSound;
            audio.Play();
            Debug.Log("[FIRE] pulse charge canon");
            Rigidbody2D bullet = (Rigidbody2D)Instantiate(projectile, transform.position, transform.rotation);
            bullet.AddForce(transform.up * 7000f);
        }

        chargeLevel = 0;
        readyToFire = false;
        
    }
}
