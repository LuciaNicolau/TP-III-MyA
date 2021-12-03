using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour, ICollectable
{
    public Player player;
    bool isActive;
    public void Collect()
    {
        isActive = true;
        if (isActive == true)
        {
            Speed();
            player.addSpeed.Play();
        }
        else
            ReturnToNormalSpeed();
        gameObject.SetActive(false);
    }

    void Speed()
    {
        StartCoroutine(WaitForSpeed());
    }

    void ReturnToNormalSpeed()
    {
        player._speed = 25;
    }

    IEnumerator WaitForSpeed()
    {
        player._speed = player._speed + 25;
        new WaitForSeconds(3f);
        isActive = false;
        yield return null;

    }
}
