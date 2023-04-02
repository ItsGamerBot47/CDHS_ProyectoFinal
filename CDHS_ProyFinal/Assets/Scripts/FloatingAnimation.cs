using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingAnimation : MonoBehaviour
{
    private enum FloatType{ XL, L, M}
    [SerializeField] private FloatType choosingAnimation;
    [SerializeField] private Animator actualAnimation;

    private void FixedUpdate()
    {
        switch (choosingAnimation)
        {
            case FloatType.XL:
            {
                actualAnimation.SetInteger("Float", 1);
                break;
            }
            case FloatType.L:
            {
                actualAnimation.SetInteger("Float", 2);
                break;
            }
            case FloatType.M:
            {
                actualAnimation.SetInteger("Float", 3);
                break;
            }
        }
    }
}
