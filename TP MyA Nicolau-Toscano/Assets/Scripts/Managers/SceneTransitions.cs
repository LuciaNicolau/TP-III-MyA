using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{
    public ManagerUI managerUI;

    [SerializeField]
    private float _timeForTransition;

    private void Start()
    {
        EventManager.Subscribe("GameOver", YouLost);
        EventManager.Subscribe("GameWon", YouWon);
    }

    public void Resume()
    {
        managerUI.InactivePause();
        Time.timeScale = 1f;
    }

    public void YouWon(params object[] parameters)
    {
        SceneManager.LoadScene("YouWon");
    }

    public void YouLost(params object[] parameters)
    {
        StartCoroutine(WaitForLoadScene(2));
    }
    IEnumerator WaitForLoadScene(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("YouLost");
    }
    public void Levels()
    {
        SceneManager.LoadScene("Levels");
    }
    public void Level1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void Level2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void Level3()
    {
        SceneManager.LoadScene("Level3");
    }
    public void Play()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Levels");
    }

    public void Rules()
    {
        SceneManager.LoadScene("Rules");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Exit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
