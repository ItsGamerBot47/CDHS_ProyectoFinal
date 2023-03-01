using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvaController : MonoBehaviour
{
    [SerializeField] private Image healthImage;
    [SerializeField] private TMP_Text healthCounter;

    private void Update()
    {
        GameManager.instance.ChangingLifeColor(healthImage);
        healthCounter.text = GameManager.instance.GetTotalLife().ToString();
    }
}
