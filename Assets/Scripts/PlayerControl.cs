using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public static readonly int rollkHash = Animator.StringToHash("Roll");
    public static readonly int attackHash = Animator.StringToHash("Ataque");
    public static readonly int blendHash = Animator.StringToHash("Blend");
    public static readonly int velxHash = Animator.StringToHash("VelX");
    public static readonly int velyHash = Animator.StringToHash("VelY");

    Animator ani;

    public AudioSource audioSource1;
    


    public float speed = 20f;
    public float rotSpeed = 10f;
    public float horizontalInput, verticalInput;
   
    private Animator animator;
   
    private void Start()
    {
        animator = GetComponent<Animator>();

        audioSource1 = GetComponent<AudioSource>();
        

    }



    void Update()
    {

        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);

        transform.Rotate(Vector3.up, rotSpeed * Time.deltaTime * horizontalInput);

        animator.SetFloat(velxHash, horizontalInput);
        animator.SetFloat(velyHash, verticalInput);
       
        if (Input.GetKey("c"))
        {
            animator.SetBool(attackHash, true);

            audioSource1.Play();
        }

        

        if (Input.GetKeyDown("q"))
        {
            transform.Translate(Vector3.forward * 200* Time.deltaTime * verticalInput);

            animator.SetBool("Roll", true);
        }


    }

  







}
