using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Stats")]
    public float maxSpeed;
    public float AccelerationSpeed;
    public float Jumpheight;
    public float StreamLine;

    [Header("Public Class Variables")]
    public bool Locked = false;

    [Header("Public Placers")]
    public Rigidbody rb;
    public Transform GroundCheck;
    public LayerMask GroundMask;
    public Camera MainCamera;

    float UniversalTimer = 0f;

    float angleToFacex = 0.01f;
    float angleToFacez = 0.01f;
    float yRotation;

    float GroundDrag;
    bool Grounded;
    float groundDistance;

    float HorizontalInput;
    float VerticalInput;
    Vector3 moveDir;

    void Start()
    {
        GroundDrag = maxSpeed * 0.3f;
        AccelerationSpeed = (maxSpeed * 10) * Time.deltaTime;
    }

    private void MyInput()
    {
        VerticalInput = Input.GetAxisRaw("Vertical");
        HorizontalInput = Input.GetAxisRaw("Horizontal");
    }

    private void MovePlayer()
    {
        moveDir = this.transform.forward * VerticalInput + this.transform.right * HorizontalInput;

        if (Grounded)
        { rb.AddForce(moveDir.normalized * AccelerationSpeed * 10f, ForceMode.Force); }

        else if (!Grounded)
        { rb.AddForce(moveDir.normalized * AccelerationSpeed * 10f * StreamLine, ForceMode.Force); }
    }

    private void SpeedControl()
    {
        Vector3 FlatVal = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z);

        if (FlatVal.magnitude > maxSpeed)
        {
            Vector3 LimitedVel = FlatVal.normalized * maxSpeed;
            rb.velocity = new Vector3(LimitedVel.x, LimitedVel.y, LimitedVel.z);
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * Jumpheight, ForceMode.Impulse);
    }

    void Update()
    {
        MyInput();
        SpeedControl();

        if (UniversalTimer >= 5)
        { UniversalTimer = 0; }
        else
        { UniversalTimer++; }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameObject[] SpellSlots = GameObject.FindGameObjectsWithTag("Hot Bar");
            foreach (GameObject x in SpellSlots)
            {
                x.GetComponent<SpellSlots>().ChangeActive();
            }
        }

        if (Physics.CheckSphere(GroundCheck.position, groundDistance, GroundMask))
        {
            groundDistance = 0.4f;
            rb.freezeRotation = true;
            Grounded = true;

            if (Input.GetKeyDown(KeyCode.Space))
            { Jump(); }
        }
        else
        {
            Grounded = false;
            rb.drag = 0;
            rb.freezeRotation = false;
            groundDistance = 0.7f;
        }

        yRotation = MainCamera.GetComponent<PlayerCamera>().yRotation;
        Vector3 PlayerForward = new Vector3(angleToFacex, yRotation, angleToFacez);
        if (Grounded || !this.GetComponent<ToggleMenu>().InMenu)
        {
            this.transform.rotation = Quaternion.Euler(PlayerForward);
        }

    }

    void FixedUpdate()
    {
        if (Grounded)
        {
            rb.drag = GroundDrag;
        }
        if (!Locked)
        { MovePlayer(); }
    }
}
