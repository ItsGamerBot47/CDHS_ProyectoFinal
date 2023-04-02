using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffBoundariesZone : MonoBehaviour
{
    
    [SerializeField] private Transform positionToReturn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = positionToReturn.position;
            GameManager.instance.ModifyLife(-1);
        }
    }
}
