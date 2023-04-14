using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TestPlayerMovement : MonoBehaviour
{
    private enum MovementWay{ MinusZ, PlusZ, MinusX, PlusX}
    [SerializeField] private MovementWay PlayerMovement;
    [SerializeField] private GameObject shootView;
    [SerializeField] private float speedMovement = 10.0f;
    [SerializeField] private float rotationSpeed = 8.0f;
    [SerializeField] private float jumpForce = 20.0f;
    public UnityEvent<float> OnLeftClickTest;
    private RaycastBox raycastInfo;
    private float chargeProgress = 0.0f;
    private Rigidbody rbStuff;
    private Animator animStuff;
    private Vector3 currentRotation;
    private bool idleRotation;
    private Vector3 directionToRotate;

    private void Awake()
    {
        rbStuff = GetComponent<Rigidbody>();
        animStuff = GetComponent<Animator>();
        raycastInfo = GetComponent<RaycastBox>();
        if (rbStuff == null)
            Debug.LogError("Falta componente Rigbody en " + gameObject.name + ".");
        if (animStuff == null)
            Debug.LogError("Falta componente Animator en " + gameObject.name + ".");
        if (raycastInfo == null)
            Debug.LogError("Falta scrip RaycastBox en " + gameObject.name + ".");
    }
    private void FixedUpdate()
    {
        MovementInput();
        JumpMechanic();
        PrepareCharge();
    }

    private void MovePlayer(Vector3 direction)
    {
        SetAnimatorBool("OnMovement", true);
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
                if (Input.GetKey(KeyCode.A))
                    MovePlayer(Vector3.right);
                if (Input.GetKey(KeyCode.D))
                    MovePlayer(Vector3.left);
                break;
            }
            case MovementWay.MinusX:
            {
                if (Input.GetKey(KeyCode.A))
                    MovePlayer(Vector3.back);
                if (Input.GetKey(KeyCode.D))
                    MovePlayer(Vector3.forward);
                break;
            }
            case MovementWay.PlusZ:
            {
                if (Input.GetKey(KeyCode.A))
                    MovePlayer(Vector3.left);
                if (Input.GetKey(KeyCode.D))
                    MovePlayer(Vector3.right);
                break;
            }
            case MovementWay.PlusX:
            {
                if (Input.GetKey(KeyCode.A))
                    MovePlayer(Vector3.back);
                if (Input.GetKey(KeyCode.D))
                    MovePlayer(Vector3.forward);
                break;
            }
        }
        //  Rotar
        if (idleRotation)   RotatePlayer(directionToRotate);
    }
    private bool JumpCheck()
    {
        return raycastInfo.ReturnRaycast(gameObject);
    }
    private void JumpMechanic()
    {
        if (Input.GetKey(KeyCode.Space) && JumpCheck())
        {
            rbStuff.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            SetAnimatorBool("OnMovement", true);
        }
    }
    private void PrepareCharge()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            chargeProgress += Time.deltaTime;
            if (chargeProgress >= 0.5f)
                chargeProgress = 0.5f;
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))     chargeProgress = 0.0f;
        OnLeftClickTest?.Invoke(2 * chargeProgress);
    }
    public void SetAnimatorBool(string name, bool state)
    {
        animStuff.SetBool(name, state);
    }
}
