using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NewPlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject thirdPersonView;
    [SerializeField] private GameObject firstPersonView;
    [SerializeField] private GameObject shootView;
    [SerializeField] private float speedMovement = 10.0f;
    [SerializeField] private float rotationSpeed = 8.0f;
    [SerializeField] private float jumpForce = 20.0f;
    [SerializeField] private Vector3 raycastBoxSize;
    [SerializeField] private float raycastMaxDist;
    [SerializeField] private LayerMask raycastLayers;
    [SerializeField] public UnityEvent<float> OnLeftClick;
    [SerializeField] public UnityEvent<int> OnRightClick;
    private float chargeProgress = 0.0f;
    private Rigidbody rbStuff;
    private Vector3 currentRotation;

    private void Awake()
    {
        rbStuff = GetComponent<Rigidbody>();
        if (rbStuff == null)
            Debug.LogError("Falta componente Rigbody en " + gameObject.name + ".");
    }
    private void FixedUpdate()
    {
        MovementInput();
        RotationInput();
        ChangeCamera();
        PrepareCharge();
        JumpMechanic();
    }

    private void OnDrawGizmos()
    {
        DrawRaycast();
    }

    private void MovePlayer(Vector3 direction)
    {
        transform.Translate(direction.normalized * (Time.deltaTime * speedMovement), Space.Self);
    }
    private void MovementInput()
    {
        if (Input.GetKey(KeyCode.W))    MovePlayer(Vector3.forward);
        if (Input.GetKey(KeyCode.A))    MovePlayer(Vector3.left);
        if (Input.GetKey(KeyCode.S))    MovePlayer(Vector3.back);
        if (Input.GetKey(KeyCode.D))    MovePlayer(Vector3.right);
    }
    private void RotationInput()
    {
        currentRotation.x += Input.GetAxis("Mouse X") * rotationSpeed;
        currentRotation.y -= Input.GetAxis("Mouse Y") * rotationSpeed;

        if (currentRotation.y <= -60)   currentRotation.y = -60;
        if (60 <= currentRotation.y)    currentRotation.y = 60;

        transform.rotation = Quaternion.Euler(0, currentRotation.x, 0);
        shootView.transform.rotation = Quaternion.Euler(currentRotation.y, currentRotation.x, 0);
        thirdPersonView.transform.rotation = Quaternion.Euler(currentRotation.y, currentRotation.x, 0);
        firstPersonView.transform.rotation = Quaternion.Euler(currentRotation.y, currentRotation.x, 0);
    }
    private bool JumpCheck()
    {
        return (Physics.BoxCast(transform.position, raycastBoxSize, -transform.up, transform.rotation, raycastMaxDist, raycastLayers));
    }
    private void JumpMechanic()
    {
        if (Input.GetKey(KeyCode.Space) && JumpCheck())
            rbStuff.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void ChangeCamera()
    {
        if (Input.GetKey(KeyCode.Mouse1))       OnRightClick?.Invoke(1);
        if (Input.GetKeyUp(KeyCode.Mouse1))     OnRightClick?.Invoke(0);
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
        OnLeftClick?.Invoke(2 * chargeProgress);
    }
    private void DrawRaycast()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position - transform.up * raycastMaxDist, raycastBoxSize);
    }
}
