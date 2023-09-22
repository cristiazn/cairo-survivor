using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movimiento : MonoBehaviour
{
    [Header("Barras")]
    [SerializeField] private Slider barraVida;

    [Header("Rebote")]
    public float velocidadRebote;

    [Header("Movimiento")]
    public float Speed;
    public float JumpForce;
    public LayerMask queEsSuelo;
    public Transform controladorSuelo;
    public Vector3 dimensionesCaja;
    public bool enSuelo;
    private bool salto = false;
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
         
         if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
         {
            salto = true;
         }
     }

    
    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal * Speed, Rigidbody2D.velocity.y);
        enSuelo = Physics2D.OverlapBox(controladorSuelo.position, dimensionesCaja, 0f, queEsSuelo);

        Jump(salto);
        salto = false;
    }
    public void Jump(bool saltar)
    {
        if(enSuelo && saltar)

        {
            enSuelo = false;
            Rigidbody2D.AddForce(new Vector2(0f, JumpForce));
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(controladorSuelo.position, dimensionesCaja);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Piso")
        {
            barraVida.value -= 0.1f;
        }
        if (collision.gameObject.tag == "Caida")
        {
            barraVida.value -= 1f;
        }
    }

    public void DañoVida(float daño)
    {
        barraVida.value -= daño;
    }
    public void Rebote()
    {
        Rigidbody2D.velocity = new Vector2(Rigidbody2D.velocity.x, velocidadRebote);
    }



}
