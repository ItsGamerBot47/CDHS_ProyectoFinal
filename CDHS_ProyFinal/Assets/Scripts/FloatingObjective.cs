using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingObjective : MonoBehaviour
{
    private enum FloatingObjMode {UpDown, DownUp}
    [SerializeField] private FloatingObjMode floatMode;
    [SerializeField] private Animator actualAnimation;

    private void FixedUpdate()
    {
        switch (floatMode)
        {
            case FloatingObjMode.UpDown:
            {
                actualAnimation.SetInteger("Animation", 1);
                break;
            }
            case FloatingObjMode.DownUp:
            {
                actualAnimation.SetInteger("Animation", 2);
                break;
            }
        }
    }
}
