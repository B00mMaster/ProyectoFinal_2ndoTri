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

    [SerializeField]private ParticleSystem particulas;

    Animator ani;

    public AudioSource swingSwordSource;



    public float speed = 20f;
    public float rotSpeed = 10f;
    public float horizontalInput, verticalInput;
   
    private Animator animator;

    private Rigidbody rigidbody;

    private bool rollingInTheDeep;
   
    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        

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

        

        if (Input.GetKeyDown("q"))
        {
            transform.Translate(Vector3.forward * 200* Time.deltaTime * verticalInput);

            particulas.Play();


            //rigidbody.constraints = RigidbodyConstraints.FreezePositionY;
           // rollingInTheDeep = true;
          //  animator.SetBool("Roll", true);
        }


    }



    public void ResetRoll()
    {
        //rigidbody.constraints = RigidbodyConstraints.None;
        //rollingInTheDeep = false;
      //  animator.SetBool(rollkHash, false);
    }





}
