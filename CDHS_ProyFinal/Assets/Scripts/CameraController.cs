using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField] public int cameraToFocus;
    [SerializeField] private List<CinemachineVirtualCamera> cameraList;

    private void Awake()
    {
        if (cameraList.Count == 0)
            Debug.LogError("Falta añadir objetos a" + gameObject.name);
    }
    private void FixedUpdate()
    {
        ChangeCamera(cameraToFocus);
    }

    public int GetCameraNumber()
    {
        return cameraToFocus;
    }
    public void SetCameraNumber(int number)
    {
        cameraToFocus = number;
    }
    public void ChangeCamera(int index)
    {
        //  Validar
        if (index < 0)                      index = 0;
        else if (index >= cameraList.Count) index = cameraList.Count - 1;
        //  Operar
        for (int i = 0; i < cameraList.Count; i++)
        {
            if (i == index)
                cameraList[i].gameObject.SetActive(true);
            else
                cameraList[i].gameObject.SetActive(false);
        }
    }
}
