using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour, ICollectable
{
    public void Collect()
    {
        gameObject.SetActive(false);
    }
    
}
