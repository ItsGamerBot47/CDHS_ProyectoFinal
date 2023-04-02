using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvaController : MonoBehaviour
{
    [SerializeField] private Image healthImage;
    [SerializeField] private TMP_Text healthCounter;
    [SerializeField] private Button pauseMenu;
    [SerializeField] private Image chargeBar;
    [SerializeField] private Image firstPersonDot;

    private void Update()
    {
        UpdatingHealthImage();
        ShowPauseMenu();
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
}
