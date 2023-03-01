using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private int totalLife = 5;
    private TestPlayerMovement player;
    public TestPlayerMovement GetTestPlayerMovement()
    {
        return player;
    }
    public void SetPlayerMovement(TestPlayerMovement playerToAssign)
    {
        player = playerToAssign;
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
    private void Update()
    {
        GameOver();
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
    public void ModifyLife(int lifeToChange)
    {
        totalLife += lifeToChange;
    }
    public void OfficialGameOver()
    {
        Application.Quit();
    }
    public void GameOver()
    {
        if (totalLife == 0)
        {
            //  Prueba
            Debug.LogWarning("Game Over. Not your fault tho, the game's.");
            Debug.Break();
        }
    }
}
