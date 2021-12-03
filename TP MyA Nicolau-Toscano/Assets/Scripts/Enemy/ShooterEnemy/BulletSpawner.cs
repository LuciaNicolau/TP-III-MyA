using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner :  Enemy
{
    public static BulletSpawner instance;
    public Bullet bullet;
    private float _restartTimeShoot;
    public float fireRate;

    public Transform player;

    public ObjectPool<Bullet> pool;
    private void Awake()
    {
        _restartTimeShoot = fireRate;
        fireRate = 0;
    }
    private void Start()
    {
        instance = this;

        pool = new ObjectPool<Bullet>(BulletReturn, Bullet.TurnOn, Bullet.TurnOff, 10);
    }

    private void FixedUpdate()
    {
        fireRate -= Time.deltaTime;
    }
    public Bullet BulletReturn()
    {
        return Instantiate(bullet);
    }

    private void OnTriggerStay(Collider other)
    {
        var damageable = other.GetComponent<IDamageable>();
        if (damageable != null)
        {
            Shoot();
        }

    }
    void Shoot()
    {
        if (fireRate < 0)
        {
            var b = pool.GetObject();
            b.transform.position = transform.position;
            b.transform.forward = transform.forward;
            fireRate = _restartTimeShoot;
        }
    }

}
