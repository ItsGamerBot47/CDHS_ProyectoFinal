using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    [SerializeField] private GameObject bulletObject;
    [SerializeField] private float cooldownShot = 0.5f;
    private GameObject auxPrefab;
    private float totalTime;
    private bool bulletShot;

    private void FixedUpdate()
    {
        ShotProcess();
    }

    private void ShotProcess()
    {
        bulletShot = Input.GetKey(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Mouse0);
        if (bulletShot)
        {
            totalTime += Time.deltaTime;
            if (totalTime > cooldownShot)
                totalTime = 0;
            if (totalTime == 0)
                Shooting();
        }
        else
            totalTime = 0;
    }
    private void Shooting()
    {
        auxPrefab = Instantiate(bulletObject, transform.position, transform.rotation) as GameObject;
    }
}
