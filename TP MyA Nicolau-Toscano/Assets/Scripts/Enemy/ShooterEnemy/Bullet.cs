using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Enemy
{
    public float speed;
    public float maxDistance;

    float _currentDistance;

    private void Reset()
    {
        _currentDistance = 0;
    }
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        _currentDistance += speed * Time.deltaTime;

        if (_currentDistance >= maxDistance)
        {
            BulletSpawner.instance.pool.ReturnObject(this);
        }
    }

    public static void TurnOn(Bullet b)
    {
        b.Reset();
        b.gameObject.SetActive(true);
    }

    public static void TurnOff(Bullet b)
    {
        b.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider trig)
    {
        var damageable = trig.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.SubtractLifeFunc(FlyweightPointer.Enemy.damage);
        }

    }
}
