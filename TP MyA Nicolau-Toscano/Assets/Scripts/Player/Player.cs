using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable, IObservable
{
    public bool isDead;

    public float _speed;
    [SerializeField]
    private float _jumpForce;
    public float life = 100;
    public float maxLife = 100;
    [SerializeField]
    private float minLife;

    public ManagerUI managerUI;

    Control _control;
    Movement _movement;

    private Rigidbody _rb;

    List<IObserver> _allObservers = new List<IObserver>();

    public ParticleSystem damage;
    public ParticleSystem addLife;
    public ParticleSystem addSpeed;

    void Awake()
    {
        EventManager.Subscribe("GameOver", Dead);

        _rb = GetComponent<Rigidbody>();

        _movement = new Movement(transform, _speed, _jumpForce, _rb);
        _control = new Control(this, _movement);

    }

    private void Start()
    {
        StartLifeFunc(life);

    }

    void FixedUpdate()
    {
        _control.OnUpdate();
    }


    public void PowerUpMovement(params object[] parameters)
    {
        transform.position += Vector3.forward * _speed * Time.deltaTime;
    }

    private void OnCollisionStay(Collision collision)
    {
        _control.Jump();
    }
    void OnCollisionEnter(Collision collision)
    {
        var collectable = collision.gameObject.GetComponent<ICollectable>();

        if (collectable != null)
        {
            if (isDead == false & collectable != null)
            {
                collectable.Collect();
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        var obj = other.gameObject.GetComponent<ICollectable>();

        if (isDead == false & obj != null)
        {
            obj.Collect();
        }
    }
    public void StartLifeFunc(float life)
    {
        life = maxLife;
        NotifyToObservers(life, maxLife);
    }

    public void AddLifeFunc(float dmg)
    {
        life += dmg;
        if (life > maxLife)
            life = maxLife;
        NotifyToObservers(life, maxLife);
    }

    public void SubtractLifeFunc(float dmg)
    {
        life -= dmg;
        NotifyToObservers(life, maxLife);
        damage.Play();
        if (life < minLife)
        {
            EventManager.Trigger("GameOver");
        }
    }

    public void Dead(params object[] parameters)
    {
        _speed = 0;
        isDead = true;
        life = minLife;
    }

    public void Subscribe(IObserver obs)
    {
        if (!_allObservers.Contains(obs))
            _allObservers.Add(obs);

    }

    public void Unsubscribe(IObserver obs)
    {
        if (_allObservers.Contains(obs))
            _allObservers.Remove(obs);
    }

    public void NotifyToObservers(float life, float maxLife)
    {
        for (int i = 0; i < _allObservers.Count; i++)
            _allObservers[i].Notify(life, maxLife);
    }

}
