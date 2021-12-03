using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{    void OnCollisionEnter(Collision trig)
    {
        var damageable = trig.collider.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.SubtractLifeFunc(FlyweightPointer.Enemy.damage);
        }

    }
}
