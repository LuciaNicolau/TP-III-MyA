using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddLifePowerUp : PowerUp
{
    [SerializeField]
    private int _addLife = 10;
    void OnTriggerEnter(Collider trig)
    {
        var damageable = trig.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.AddLifeFunc(_addLife);
        }
    }
}
