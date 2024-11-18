using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; //el game manager controla las variables del juego y es accesible a todos
    private float time;
    private int points;
    public enum GameManagerVariables { TIME, POINTS };//para facilitar el codigo

    private void Awake()
    {
        if (!instance)
        {
            instance = this;//se instancia el objecto
            DontDestroyOnLoad(gameObject);// no se destruye entre cargas
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        time += Time.deltaTime;
        if ( Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
    }

    // getter
    public float GetTime()
    {
        return time;
    }

    // getter
    public int GetPoints()
    {
        return points;
    }

    // setter
    public void SetPoints(int value)
    {
        points = value;
    }


    public void ExitGame()
    {
        Debug.Log("Me cerraste wey");
        Application.Quit();
    }
    public void LoadScene(string sceneName)
    {
        time = 0;
        SceneManager.LoadScene(sceneName);
    }

    
}