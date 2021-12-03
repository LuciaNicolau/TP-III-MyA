using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddLifePowerUp : MonoBehaviour, ICollectable
{
    [SerializeField]
    private int _addLife = 10;

    public Player player;

    public void Collect()
    {
        gameObject.SetActive(false);

    }

    void OnTriggerEnter(Collider trig)
    {
        var damageable = trig.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.AddLifeFunc(_addLife);
            player.addLife.Play();
        }
    }
}
