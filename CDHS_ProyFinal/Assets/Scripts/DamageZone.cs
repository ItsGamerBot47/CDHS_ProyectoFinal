using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    [SerializeField] private Transform returnTo;
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Player"))
        {
            other.transform.position = returnTo.position;   //  Regresar a punto seleccionado
            GameManager.instance.ModifyLife(-1);            //  Restar 1 vida
        }
    }
}
