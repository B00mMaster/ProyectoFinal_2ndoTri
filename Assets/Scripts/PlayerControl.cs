using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 20f;
    public float rotSpeed = 10f;
    public float horizontalInput, verticalInput;
    private Animator animator;


    private void Start()
    {
        animator = GetComponent<Animator>();
    }



    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);

        transform.Rotate(Vector3.up, rotSpeed * Time.deltaTime * horizontalInput);

        animator.SetFloat("VelX", horizontalInput);
        animator.SetFloat("VelY", verticalInput);

      

    }
}
