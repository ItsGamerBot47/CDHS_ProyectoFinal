using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPlatform : MonoBehaviour
{
    [SerializeField] private Transform[] showPlatformOn;
    [SerializeField] private float timeToChange;
    private int index = 0;
    private float totalTime;

    private void Awake()
    {
        totalTime = 0.0f;
        index = 0;
        if (showPlatformOn.Length == 0)
            Debug.LogError("There is no object in Array[] of " + gameObject + ".");
    }
    private void Update()
    {
        LoopingMovement();
    }

    private void MoveToPoint(Vector3 point)
    {
        transform.position = point;
    }
    private void LoopPoints()
    {
        totalTime = 0.0f;
        if (index + 1 >= showPlatformOn.Length)
            index = 0;
        else
            index++;
    }
    private void LoopingMovement()
    {
        if (totalTime == 0.0f)
            MoveToPoint(showPlatformOn[index].position);
        totalTime += Time.deltaTime;
        if (totalTime >= timeToChange)
            LoopPoints();
    }
}
