using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using Oculus.Interaction.HandGrab;

public class WeaponController : MonoBehaviour, IHandGrabUseDelegate
{
    [SerializeField] private GunController _gunController;

    public void BeginUse()
    {
        _gunController.Shoot();
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
