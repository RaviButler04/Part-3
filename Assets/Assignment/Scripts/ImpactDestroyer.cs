using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactDestroyer : MonoBehaviour
{
    public void DestorySelf()
    {
        Destroy(gameObject);
    }
}
