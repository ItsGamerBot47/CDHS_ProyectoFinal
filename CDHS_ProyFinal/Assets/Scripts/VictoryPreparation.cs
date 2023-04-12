using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VictoryPreparation : MonoBehaviour
{
    [SerializeField] private float victoryProcess;
    [SerializeField] private int victoryCamera;
    [SerializeField] private UnityEvent<float> OnVictorySpace;
    [SerializeField] private UnityEvent<int> OnVictoryComplete;
    [SerializeField] private CameraController cameraScript;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            victoryProcess += (Time.deltaTime * 0.5f);
            if (victoryProcess >= 1.0f)
            {
                victoryProcess = 1.0f;
                OnVictoryComplete?.Invoke(0);
            }
            OnVictorySpace?.Invoke(victoryProcess);
            cameraScript.SetCameraNumber(victoryCamera);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            victoryProcess = 0.0f;
            OnVictorySpace?.Invoke(victoryProcess);
            cameraScript.SetCameraNumber(0);
        }
    }
}
