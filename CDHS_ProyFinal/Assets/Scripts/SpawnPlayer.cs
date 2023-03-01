using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] private GameObject playerToSpawn;

    private void Awake()
    {
        if (playerToSpawn == null)
            Debug.LogError("Falta seleccionar un objeto en " + gameObject.name);
    }
    private void Start()
    {
        Instantiate(playerToSpawn, transform.position, transform.rotation);
    }
}
