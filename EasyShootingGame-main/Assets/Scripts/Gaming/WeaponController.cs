using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using Oculus.Interaction.HandGrab;
using System;
using Cysharp.Threading.Tasks;

public class WeaponController : MonoBehaviour, IHandGrabUseDelegate
{
    [SerializeField] private GunController _gunController;
    public event Action OnAmmoEmpty;
    public event Action<int> OnAmmoChanged;
    public int AmmoCount = 0;
    private bool coolingDown = false;
    public void BeginUse()
    {
        if (AmmoCount <= 0 || coolingDown)
        {
            return;
        }
        Cooldown();
        _gunController.Shoot();
        AmmoCount--;
        OnAmmoChanged?.Invoke(AmmoCount);
        if (AmmoCount <= 0)
        {
            OnAmmoEmpty?.Invoke();
        }
        
    }

    private async void Cooldown()
    {
        if (coolingDown)
        {
            return;
        }
        coolingDown = true;
        await UniTask.Delay(200);
        coolingDown = false;
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
