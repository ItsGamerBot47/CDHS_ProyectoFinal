using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class CanvaController : MonoBehaviour
{
    [SerializeField] private Image healthImage;
    [SerializeField] private TMP_Text healthCounter;
    [SerializeField] private Button pauseMenu;
    [SerializeField] private Image chargeBar;
    [SerializeField] private Image victoryBar;
    [SerializeField] private Image firstPersonDot;
    [SerializeField] private GameObject panelVictory;

    private void Update()
    {
        ShowPauseMenu();
        UpdatingHealthImage();
    }

    private void UpdatingHealthImage()
    {
        GameManager.instance.ChangingLifeColor(healthImage);
        healthCounter.text = GameManager.instance.GetTotalLife().ToString();
    }
    private void ShowPauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))   pauseMenu.onClick.Invoke();
    }
    public void ShowFirstPersonDot(int value)
    {
        firstPersonDot.gameObject.SetActive(value == 1);
    }
    public void ChangeChargeBar(float amountBar)
    {
        chargeBar.fillAmount = amountBar;
    }
    public void ChangeVictoryBar(float amountBar)
    {
        victoryBar.fillAmount = amountBar;
        if (amountBar > 0.0f)
            panelVictory.SetActive(true);
        else
            panelVictory.SetActive(false);
    }
}
