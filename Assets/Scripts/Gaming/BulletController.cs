using UnityEngine;

public class BulletController : MonoBehaviour
{
    void Start(){
        Destroy(gameObject, 5);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Target"))
        {
            Destroy(gameObject);
        }
    }
}
