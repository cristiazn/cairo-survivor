using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movimiento : MonoBehaviour
{
    [Header("Barras")]
    [SerializeField] private Slider barraVida;
    public float Speed;
    public float JumpForce;
     private Rigidbody2D Rigidbody2D;
     private float Horizontal;
     private bool Grounded;
     private Animator Animator;

   void  Start() 
    {
     Rigidbody2D = GetComponent<Rigidbody2D>();
     Animator    = GetComponent<Animator>(); 
    }
    void Update()
    {
        if(barraVida.value == 0)
        {
            Destroy(gameObject);
        }
       
         Horizontal = Input.GetAxisRaw("Horizontal");
        if (Horizontal < 0.0f) transform.localScale = new Vector3(-10.0f, 10.0f, 10.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(10.0f, 10.0f, 10.0f);

         Animator.SetBool("running", Horizontal !=0.0f);
          Debug.DrawRay(transform.position, Vector3.down * 1.1f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector3.down, 1.1f))
        {
            Grounded = true;
        }
        else Grounded = false;  

         if (Input.GetKeyDown(KeyCode.W) && Grounded)
         {
             Jump();
         }
         }
         
         private void Jump()
         {
            Rigidbody2D.AddForce(Vector2.up * JumpForce);
         }
    
    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal * Speed, Rigidbody2D.velocity.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Piso")
        {
            barraVida.value -= 0.1f;
        }


    }



}
