using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner :  Enemy
{
    public static BulletSpawner instance;
    public Bullet bullet;

    public Transform player;

    public ObjectPool<Bullet> pool;

    private void Start()
    {
        instance = this;

        pool = new ObjectPool<Bullet>(BulletReturn, Bullet.TurnOn, Bullet.TurnOff, 10);
    }

    public Bullet BulletReturn()
    {
        return Instantiate(bullet);
    }

    private void OnTriggerEnter(Collider other)
    {
        var damageable = other.GetComponent<IDamageable>();
        if (damageable != null)
        {
            transform.LookAt(player);
            var b = pool.GetObject();
            b.transform.position = transform.position;
            b.transform.forward = transform.forward;
        }

    }
}
