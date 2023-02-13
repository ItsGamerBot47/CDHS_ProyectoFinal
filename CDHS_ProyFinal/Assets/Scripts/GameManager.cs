using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private int totalLife = 5;
    private PlayerMovement playerOnPlay;

    public PlayerMovement GetPlayerMovement()
    {
        return playerOnPlay;
    }
    public void SetPlayerMovement(PlayerMovement somePlayer)
    {
        playerOnPlay = somePlayer;
    }

    private void Update()
    {
        GameOver();
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

    public void ModifyLife(int lifeToChange)
    {
        totalLife += lifeToChange;
    }
    private void GameOver()
    {
        if (totalLife == 0)
        {
            //  Prueba
            Debug.LogWarning("Game Over. Not your fault tho, the game's.");
            Debug.Break();
        }
    }
}
