using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera[] cameras;
    private int countingInitialFrames;

    private void Awake()
    {
        if (cameras.Length == 0)
        {
            Debug.LogError("There has to be at least 1 camera on the array.");
        }
        else
        {
            //  Activar cámara de presentación
            ActivateCamera(0);
            countingInitialFrames = -1;
        }
    }
    private void Update()
    {
        countingInitialFrames = Time.frameCount;
        if (countingInitialFrames >= 180)
            ActivateCamera(1);
    }

    public void ActivateCamera(int index)
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            if (i == index)
                cameras[i].gameObject.SetActive(true);
            else
                cameras[i].gameObject.SetActive(false);
        }
    }
}
