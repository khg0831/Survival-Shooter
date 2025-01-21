using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 6.0f;

    private Animator animator;
    private Rigidbody rigidBody;   
    private Vector3 movement;     
    private float rayLength = 100.0f;
    int floorMask;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
        floorMask = LayerMask.GetMask("Floor");
    }

    public void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Move(h, v);
        Turning();
        Anim(h, v);
    }

    private void Move(float h, float v)
    {
        movement.Set(h, 0, v);
        movement = movement.normalized * speed * Time.deltaTime;
        rigidBody.MovePosition(transform.position + movement);
    }

    private void Turning()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, rayLength, floorMask))
        {
            Vector3 playerToMouse = hitInfo.point - transform.position;
            playerToMouse.y = 0;

            Quaternion rot = Quaternion.LookRotation(playerToMouse);

            rigidBody.MoveRotation(rot);
        }

    }

    private void Anim(float h, float v)
    {
        bool isWalking = (h != 0 || v != 0);
        animator.SetBool("IsWalking", isWalking);
    }
}