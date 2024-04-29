using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 50f;
    [SerializeField] private GameObject[] points;
    private int thisPoint = 0;
    public bool isRotate;

    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private LayerMask groundLayer; 
    [SerializeField] private Transform feetpos; 

    private Rigidbody rb;
    private bool isGrounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

    }

    public void Update()
    {
        if (isRotate)
        {
            Rotate();
        }
    }

    public void Jump()
    {
        isGrounded = Physics.CheckSphere(feetpos.position, 0.3f, groundLayer);
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    public void Move()
    {
        transform.DOMove(points[thisPoint].transform.position, 1);
        if (thisPoint != 3)
        {
            thisPoint++;
        }
        else
        {
            thisPoint = 0;
        }
    }

    void Rotate()
    {
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
    }
}
