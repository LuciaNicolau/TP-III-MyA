using UnityEngine;
using UnityEngine.UI;
using System;

public class LifeBar : MonoBehaviour, IObserver
{
    float _lerpSpeed;
    public Image lifeBar;
    IObservable _playerToCopy;
    public Player player;
    private void Start()
    {
        _playerToCopy = player;
        _playerToCopy.Subscribe(this);
    }

    void BarUpdate(float _life, float _maxLife)
    {
        lifeBar.fillAmount = (_life / _maxLife);
    }

    public void Notify(float life, float maxLife)
    {
        BarUpdate(life, maxLife);
    }

}