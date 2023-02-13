using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveHeal : MonoBehaviour
{
    [SerializeField] private GameObject item;
    [SerializeField] private int healthToGive;
    [SerializeField] private float respawnTime = 3.0f;
    [SerializeField] private float totalTime;
    private bool taken;

    private void Awake()
    {
        totalTime = 0.0f;
        taken = false;
    }
    private void Update()
    {
        if (taken)
        {
            item.SetActive(false);
            totalTime += Time.deltaTime;
        }
        if (totalTime >= respawnTime)
        {
            totalTime = 0.0f;
            taken = false;
            item.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        var isPlayer = other.gameObject.CompareTag("Player");
        Debug.Log("Entrando en colisión con " + other.gameObject.name + " (CON JUGADOR: " + isPlayer.ToString() + ")");
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.ModifyLife(healthToGive);
            taken = true;
        }
    }
}
