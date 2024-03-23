using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TargetController : MonoBehaviour
{
    public event Action<int> OnPlayerHit;
    [SerializeField] private ColliderTrigger Point3Collider;
    [SerializeField] private ColliderTrigger Point5Collider;
    [SerializeField] private ColliderTrigger Point10Collider;

    private void Start()
    {
        Point3Collider.OnTriggerEnter_Event += TriggerHandler_3;
        Point5Collider.OnTriggerEnter_Event += TriggerHandler_5;
        Point10Collider.OnTriggerEnter_Event += TriggerHandler_10;
    }

    private void TriggerHandler_3()
    {
        OnPlayerHit?.Invoke(3);
    }

    private void TriggerHandler_5()
    {
        OnPlayerHit?.Invoke(5);
    }

    private void TriggerHandler_10()
    {
        OnPlayerHit?.Invoke(10);
    }

    private void OnDestroy()
    {
        Point3Collider.OnTriggerEnter_Event -= TriggerHandler_3;
        Point5Collider.OnTriggerEnter_Event -= TriggerHandler_5;
        Point10Collider.OnTriggerEnter_Event -= TriggerHandler_10;
    }
}
