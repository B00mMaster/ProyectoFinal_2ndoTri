using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControl : MonoBehaviour
{
   
    public static readonly int attackHash = Animator.StringToHash("Ataque");
    public static readonly int blendHash = Animator.StringToHash("Blend");
    public static readonly int velxHash = Animator.StringToHash("VelX");
    public static readonly int velyHash = Animator.StringToHash("VelY");

    [SerializeField]private ParticleSystem particulas;

    

    public AudioSource swingSwordSource;

    public Transform respawn;

    public float speed = 20f;
    public float rotSpeed = 10f;
    public float horizontalInput, verticalInput;
   
    private Animator animator;

    private Rigidbody rb;

    private bool rollingInTheDeep;

    Vector3 posInicio;


    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        

    }



    void Update()
    {
        if(rollingInTheDeep) return;
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);

        transform.Rotate(Vector3.up, rotSpeed * Time.deltaTime * horizontalInput);

        animator.SetFloat(velxHash, horizontalInput);
        animator.SetFloat(velyHash, verticalInput);
       
        if (Input.GetKey("c"))
        {
            animator.SetBool(attackHash, true);

            swingSwordSource.Play();
        }

        if (transform.position.y < -6)
        {
            transform.position = posInicio;
            transform.position = respawn.position;
        }



    }



    public void ResetRoll()
    {
        
        
        animator.SetBool("Roll", false);
    }





}
