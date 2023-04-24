using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float vidas =10f;
    public float speed = 20f;
    public float rotSpeed = 10f;
    public float horizontalInput, verticalInput;
   
    public bool ataque;
    
    public Rigidbody rb;
    public float jump;
    public Transform groundCheck;

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

        if (Input.GetKey("c"))
        {
            animator.Play("infantry_04_attack_A");
        }
        
    
    }

  






}
