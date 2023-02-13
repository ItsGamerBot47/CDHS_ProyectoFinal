using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoosePlatformMove : MonoBehaviour
{
    public enum MoveDirecion
    {
        LeftOne, LeftTwo, LeftThree, RightOne, RightTwo, RightThree
    };
    [SerializeField] private Animator animationMove;
    [SerializeField] private MoveDirecion directionMove;
    
    private void Awake()
    {
        animationMove = GetComponent<Animator>();
        if (animationMove == null)
        {
            Debug.LogError("The object " + gameObject.name + " requires an Animator component.");
        }
    }
    private void Update()
    {
        switch (directionMove)
        {
            case MoveDirecion.LeftOne:
            {
                DoAnimation(1, false);
                break;
            }
            case MoveDirecion.LeftTwo:
            {
                DoAnimation(2, false);
                break;
            }
            case MoveDirecion.LeftThree:
            {
                DoAnimation(3, false);
                break;
            }
            case MoveDirecion.RightOne:
            {
                DoAnimation(1, true);
                break;
            }
            case MoveDirecion.RightTwo:
            {
                DoAnimation(2, true);
                break;
            }
            case MoveDirecion.RightThree:
            {
                DoAnimation(3, true);
                break;
            }
        }
    }
    void DoAnimation(int platform, bool value)
    {
        animationMove.SetInteger("PlatformNumber", platform);
        animationMove.SetBool("DirectionMovement", value);
    }
}
