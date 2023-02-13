using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalCutscene : MonoBehaviour
{
    private PlayerMovement playerToMove;
    [SerializeField] private CameraController cameraScript;
    [SerializeField] private Transform[] pathToFollow;
    private int index = 0;
    private float totalTime = 0.0f;
    [SerializeField] private float timeToEnd = 10.0f;

    private void Awake()
    {
        if (pathToFollow.Length == 0)
        {
            Debug.LogError("There has to be at least 1 transform on the array.");
        }
    }
    private void Start()
    {
        playerToMove = GameManager.instance.GetPlayerMovement();
    }
    private void Update()
    {
        if (playerToMove.GetAnimator().GetBool("ReachedEnd"))
        {
            totalTime += Time.deltaTime;
            FinalMovement();
            if (totalTime >= timeToEnd)
            {
                Debug.LogWarning("Its supposed to change to another scene but time got me real good.");
                Debug.Break();
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ChangeAnimation(true);
        }
    }

    void FinalMovement()
    {
        if (index < pathToFollow.Length)
        {
            Vector3 moveTo = pathToFollow[index].transform.position - playerToMove.transform.position;
            if (moveTo.magnitude == 0)
            {
                playerToMove.RotatePlayer(moveTo.normalized);
                index += 1;
            }  
        }        
    }
    void ChangeAnimation(bool value)
    {
        playerToMove.GetAnimator().SetBool("ReachedEnd", value);
        cameraScript.ActivateCamera(2);
    }
}
