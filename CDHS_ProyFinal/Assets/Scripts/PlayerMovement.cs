using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speedMovement = 3.0f;
    [SerializeField] private float rotationSpeed = 2.0f;
    [SerializeField] private Rigidbody physicStuff;
    [SerializeField] private Animator animationStuff;
    private bool toJump;

    private void Awake()
    {
        GameManager.instance.SetPlayerMovement(this);
        if (physicStuff == null)
        {
            Debug.LogError("The object " + gameObject.name + " requires a Rigidbody component.");
        }
        if (animationStuff == null)
        {
            Debug.LogError("The object " + gameObject.name + " requires an Animator component.");
        }
        toJump = false;
    }
    private void OnCollisionEnter(Collision other)
    {
        var canJump = other.gameObject.CompareTag("Acceptable Floor");
        Debug.Log("Entrando en colisión con " + other.gameObject.name + " (SALTAR: " + canJump.ToString() + ")");
        if (other.collider.CompareTag("Acceptable Floor"))
        {
            toJump = true;
        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.collider.CompareTag("Acceptable Floor"))
        {
            toJump = false;
        }
    }
    private void Update()
    {
        if (!animationStuff.GetBool("ReachedEnd"))
        {
            PlayerMovementDirection();
            if (Input.GetKey(KeyCode.Space) && toJump)
            {
                JumpTrigger();
                toJump = false;
            }
        }
    }

    public Animator GetAnimator()
    {
        return animationStuff;
    }
    public void MovePlayer(Vector3 direction)
    {
        transform.position += direction;
    }
    void PlayerMovementDirection()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (!toJump && animationStuff.GetBool("OnMovement"))
                MovePlayer(speedMovement * Time.deltaTime * Vector3.left);
            RotatePlayer(Vector3.left);
            MovementState(true);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (!toJump && animationStuff.GetBool("OnMovement"))
                MovePlayer(speedMovement * Time.deltaTime * Vector3.right);
            RotatePlayer(Vector3.right);
            MovementState(true);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            if (!toJump && animationStuff.GetBool("OnMovement"))
                MovePlayer(speedMovement * Time.deltaTime * Vector3.forward);
            RotatePlayer(Vector3.forward);
            MovementState(true);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            if (!toJump && animationStuff.GetBool("OnMovement"))
                MovePlayer(speedMovement * Time.deltaTime * Vector3.back);
            RotatePlayer(Vector3.back);
            MovementState(true);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow))
        {
            if (!toJump && animationStuff.GetBool("OnMovement"))
                MovePlayer(speedMovement * Time.deltaTime * (Vector3.left + Vector3.forward));
            RotatePlayer(Vector3.left + Vector3.forward);
            MovementState(true);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.DownArrow))
        {
            if (!toJump && animationStuff.GetBool("OnMovement"))
                MovePlayer(speedMovement * Time.deltaTime * (Vector3.left + Vector3.back));
            RotatePlayer(Vector3.left + Vector3.back);
            MovementState(true);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow))
        {
            if (!toJump && animationStuff.GetBool("OnMovement"))
                MovePlayer(speedMovement * Time.deltaTime * (Vector3.right + Vector3.forward));
            RotatePlayer(Vector3.right + Vector3.forward);
            MovementState(true);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow))
        {
            if (!toJump && animationStuff.GetBool("OnMovement"))
                MovePlayer(speedMovement * Time.deltaTime * (Vector3.right + Vector3.forward));
            RotatePlayer(Vector3.right + Vector3.back);
            MovementState(true);
        }
        else
        {
            MovementState(false);
        }
    }
    public void RotatePlayer(Vector3 directionToLook)
    {
        Quaternion newRotation = Quaternion.LookRotation(directionToLook);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, rotationSpeed * Time.deltaTime);
    }
    void MovementState(bool value)
    {
        animationStuff.SetBool("OnMovement", value);
    }
    void JumpTrigger()
    {
        animationStuff.SetTrigger("Jumping");
    }
}
