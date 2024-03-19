using UnityEngine;
using System;
class ColliderTrigger : MonoBehaviour
{
    public event Action OnTriggerEnter_Event = delegate { };
    private void OnTriggerEnter(Collider other)
    {
        OnTriggerEnter_Event.Invoke();
    }
}