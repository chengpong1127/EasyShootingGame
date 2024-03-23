using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using Oculus.Interaction.HandGrab;
using System;

public class WeaponController : MonoBehaviour, IHandGrabUseDelegate
{
    [SerializeField] private GunController _gunController;
    public event Action OnAmmoEmpty;
    public event Action<int> OnAmmoChanged;
    public int AmmoCount = 0;
    [ContextMenu("BeginUse")]
    public void BeginUse()
    {
        if (AmmoCount <= 0)
        {
            return;
        }
        _gunController.StartShoot();
        AmmoCount--;
        OnAmmoChanged?.Invoke(AmmoCount);
        if (AmmoCount <= 0)
        {
            OnAmmoEmpty?.Invoke();
        }
        
    }

    public float ComputeUseStrength(float strength)
    {
        return strength;
    }

    public void EndUse()
    {
    }

    void Awake(){
        Assert.IsNotNull(_gunController);
    }
    public void AddAmmo(int ammo){
        AmmoCount += ammo;
        OnAmmoChanged?.Invoke(AmmoCount);
    }
}
