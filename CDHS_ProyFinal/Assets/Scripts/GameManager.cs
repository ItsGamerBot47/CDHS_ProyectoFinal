using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private int totalScore = 0;
    [SerializeField] private int totalLife = 5;
    public event Action<int> OnDeath;

    public int GetTotalScore()
    {
        return totalScore;
    }
    public void SetTotalScore(int modifyScore)
    {
        totalScore += modifyScore;
    }
    public int GetTotalLife()
    {
        return totalLife;
    }
    public void SetTotalLife(int life)
    {
        totalLife = life;
    }

    private void Awake()
    {
        if (instance != null)   Destroy(gameObject);
        else
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
    }
    private void Start()
    {
        OnDeath += ReturnToTitle;
    }
    private void Update()
    {
        if (totalLife == 0)
            OnDeath?.Invoke(0);
    }

    public void LoadSceneWithName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void ChangingLifeColor(Image lifeImage)
    {
        Color lifeColor;
        if (totalLife == 0)         lifeColor = Color.white;
        else if (totalLife <= 2)    lifeColor = Color.red;
        else if (totalLife == 3)    lifeColor = Color.yellow;
        else                        lifeColor = Color.green;
        ChangeLifeColor(lifeImage, lifeColor);
    }
    public void ChangeLifeColor(Image imageToChange, Color rgb)
    {
        imageToChange.color = rgb;
    }
    public void ReturnToTitle(int lifeOnZero)
    {
        LoadSceneWithName("Menú Principal");
        UnlockCursorMode();
        SetTotalLife(5);
    }
    public void ModifyLife(int lifeToChange)
    {
        totalLife += lifeToChange;
    }
    public void QuittingGame()
    {
        Application.Quit();
    }
    public void GameOver()
    {
        Debug.LogWarning("Game Over. Not your fault tho, the game's.");
        Debug.Break();
    }
    public void ProceedGame(int time)
    {
        if (time < 0)   time = 0;
        if (1 < time)   time = 1;
        Time.timeScale = time;
    }
    public void LockCursorMode()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void UnlockCursorMode()
    {
        Cursor.lockState = CursorLockMode.None;
    }
}
