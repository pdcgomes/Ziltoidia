using UnityEngine;
using System.Collections;

public class WeaponControls : MonoBehaviour
{
    public LaserCanon quickFireWeapon;
    public PulseChargeCanon chargeWeapon;
    public BombCanon bombWeapon;
    
    void Start()
    {
    }
    
    void Update()
    {
        if(Input.GetButtonDown("Fire1")) {
            quickFireWeapon.Fire();
        }
        if(Input.GetButton("Fire2")) {
            chargeWeapon.Charge();
            return;
        }
        if(Input.GetButtonUp("Fire2")) {
            chargeWeapon.Fire();
        }
    }
}

