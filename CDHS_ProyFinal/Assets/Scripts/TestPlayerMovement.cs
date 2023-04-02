using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestPlayerMovement : MonoBehaviour
{
    private enum MovementWay{ MinusZ, PlusZ, MinusX, PlusX}
    [SerializeField] private MovementWay PlayerMovement;
    [SerializeField] private float speedMovement = 5.0f;
    [SerializeField] private float rotationSpeed = 15.0f;
    private bool idleRotation;
    private Rigidbody rbStuff;
    private Vector3 directionToRotate;

    private void Awake()
    {
        rbStuff = GetComponent<Rigidbody>();
        if (rbStuff == null)
            Debug.LogError("Falta componente Rigbody en " + gameObject.name + ".");
    }
    private void Update()
    {
        MovementInput();
    }

    private void MovePlayer(Vector3 direction)
    {
        transform.position += direction.normalized * (Time.deltaTime * speedMovement);
        directionToRotate = direction.normalized;
        idleRotation = true;
    }
    private void RotatePlayer(Vector3 directionToLook)
    {
        Quaternion newRotation = Quaternion.LookRotation(directionToLook);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, rotationSpeed * Time.deltaTime);
        if (newRotation == transform.rotation)
            idleRotation = false;
    }
    private void MovementInput()
    {
        //  Mover
        switch (PlayerMovement)
        {
            case MovementWay.MinusZ:
            {
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    if (Input.GetKey(KeyCode.UpArrow))
                        MovePlayer(Vector3.right + Vector3.back);
                    else if (Input.GetKey(KeyCode.DownArrow))
                        MovePlayer(Vector3.right + Vector3.forward);
                    else
                        MovePlayer(Vector3.right);
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    if (Input.GetKey(KeyCode.UpArrow))
                        MovePlayer(Vector3.left + Vector3.back);
                    else if (Input.GetKey(KeyCode.DownArrow))
                        MovePlayer(Vector3.left + Vector3.forward);
                    else
                        MovePlayer(Vector3.left);
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    if (Input.GetKey(KeyCode.LeftArrow))
                        MovePlayer(Vector3.forward + Vector3.right);
                    else if (Input.GetKey(KeyCode.RightArrow))
                        MovePlayer(Vector3.forward + Vector3.left);
                    else
                        MovePlayer(Vector3.forward);
                }
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    if (Input.GetKey(KeyCode.LeftArrow))
                        MovePlayer(Vector3.back + Vector3.right);
                    else if (Input.GetKey(KeyCode.RightArrow))
                        MovePlayer(Vector3.back + Vector3.left);
                    else
                        MovePlayer(Vector3.back);
                }
                break;
            }
            case MovementWay.MinusX:
            {
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    if (Input.GetKey(KeyCode.UpArrow))
                        MovePlayer(Vector3.back + Vector3.left);
                    else if (Input.GetKey(KeyCode.DownArrow))
                        MovePlayer(Vector3.back + Vector3.right);
                    else
                        MovePlayer(Vector3.back);
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    if (Input.GetKey(KeyCode.UpArrow))
                        MovePlayer(Vector3.forward + Vector3.left);
                    else if (Input.GetKey(KeyCode.DownArrow))
                        MovePlayer(Vector3.forward + Vector3.right);
                    else
                        MovePlayer(Vector3.forward);
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    if (Input.GetKey(KeyCode.LeftArrow))
                        MovePlayer(Vector3.right + Vector3.back);
                    else if (Input.GetKey(KeyCode.RightArrow))
                        MovePlayer(Vector3.right + Vector3.forward);
                    else
                        MovePlayer(Vector3.right);
                }
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    if (Input.GetKey(KeyCode.LeftArrow))
                        MovePlayer(Vector3.left + Vector3.back);
                    else if (Input.GetKey(KeyCode.RightArrow))
                        MovePlayer(Vector3.left + Vector3.forward);
                    else
                        MovePlayer(Vector3.left);
                }
                break;
            }
            case MovementWay.PlusZ:
            {
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    if (Input.GetKey(KeyCode.UpArrow))
                        MovePlayer(Vector3.left + Vector3.forward);
                    else if (Input.GetKey(KeyCode.DownArrow))
                        MovePlayer(Vector3.left + Vector3.back);
                    else
                        MovePlayer(Vector3.left);
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    if (Input.GetKey(KeyCode.UpArrow))
                        MovePlayer(Vector3.right + Vector3.forward);
                    else if (Input.GetKey(KeyCode.DownArrow))
                        MovePlayer(Vector3.right + Vector3.back);
                    else
                        MovePlayer(Vector3.right);
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    if (Input.GetKey(KeyCode.LeftArrow))
                        MovePlayer(Vector3.back + Vector3.left);
                    else if (Input.GetKey(KeyCode.RightArrow))
                        MovePlayer(Vector3.back + Vector3.right);
                    else
                        MovePlayer(Vector3.back);
                }
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    if (Input.GetKey(KeyCode.LeftArrow))
                        MovePlayer(Vector3.forward + Vector3.left);
                    else if (Input.GetKey(KeyCode.RightArrow))
                        MovePlayer(Vector3.forward + Vector3.right);
                    else
                        MovePlayer(Vector3.forward);
                }
                break;
            }
            case MovementWay.PlusX:
            {
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    if (Input.GetKey(KeyCode.UpArrow))
                        MovePlayer(Vector3.back + Vector3.right);
                    else if (Input.GetKey(KeyCode.DownArrow))
                        MovePlayer(Vector3.back + Vector3.left);
                    else
                        MovePlayer(Vector3.back);
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    if (Input.GetKey(KeyCode.UpArrow))
                        MovePlayer(Vector3.forward + Vector3.right);
                    else if (Input.GetKey(KeyCode.DownArrow))
                        MovePlayer(Vector3.forward + Vector3.left);
                    else
                        MovePlayer(Vector3.forward);
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    if (Input.GetKey(KeyCode.LeftArrow))
                        MovePlayer(Vector3.left + Vector3.back);
                    else if (Input.GetKey(KeyCode.RightArrow))
                        MovePlayer(Vector3.left + Vector3.forward);
                    else
                        MovePlayer(Vector3.left);
                }
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    if (Input.GetKey(KeyCode.LeftArrow))
                        MovePlayer(Vector3.right + Vector3.back);
                    else if (Input.GetKey(KeyCode.RightArrow))
                        MovePlayer(Vector3.right + Vector3.forward);
                    else
                        MovePlayer(Vector3.right);
                }
                break;
            }
        }
        //  Rotar
        if (idleRotation)                       RotatePlayer(directionToRotate);
    }
}
