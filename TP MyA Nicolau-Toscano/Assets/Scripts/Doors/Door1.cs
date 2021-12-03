using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door1 : MonoBehaviour
{
    public SceneTransitions sceneTransitions;
    void OnCollisionEnter(Collision trig)
    {
        var damageable = trig.collider.GetComponent<IDamageable>();
        if (damageable != null)
        {
            sceneTransitions.Level2();
        }

    }
}
