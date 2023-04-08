using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    [SerializeField] private List<Transform> movementPoints;
    [SerializeField] private float speedMovement = 1.0f;
    private int index = 0;

    private void Awake()
    {
        index = 0;
        if (movementPoints.Count == 0)
            Debug.LogError("There is no object in List<> of " + gameObject + ".");
    }
    private void Update()
    {
        LoopingMovement();
    }

    private void GoToPoint(Vector3 pointPosition)
    {
        transform.position += pointPosition * speedMovement * Time.deltaTime;
    }
    private void LoopPoints()
    {
        if (index + 1 >= movementPoints.Count)
            index = 0;
        else
            index++;
    }
    private void LoopingMovement()
    {
        Vector3 directionToGo = movementPoints[index].position - transform.position;
        var directionToReallyGo = directionToGo.normalized;
        GoToPoint(directionToReallyGo);
        var distanceFromDirection = directionToGo.magnitude;
        if (distanceFromDirection <= 0.02f)
            LoopPoints();
    }
}
