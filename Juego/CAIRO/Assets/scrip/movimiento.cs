using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class movimiento : MonoBehaviour
{
    [Header("Golpe")]
    public Transform controladorGolpe;
    public float radioGolpe;
    public float dañoEnemigo;
    public float tiempoGolpe;
    public float tiempoSiguienteGolpe;

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
     private Animator Animator;

    [Header("Puente - Enemigo (Checo Acosta)")]
    public GameObject Enemigo;
    public GameObject puente;

    [Header("UI victoria")]
    public GameObject UIPause;
    public GameObject btnPause;
    public GameObject barraVidaC;
    public GameObject UIVictoria;

   


    void  Start() 
    {
     Rigidbody2D = GetComponent<Rigidbody2D>();
     Animator    = GetComponent<Animator>(); 
    }
    void Update()
    {
        if(Enemigo == null)
        {
            puente.SetActive(true);
        }

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
        if (tiempoSiguienteGolpe > 0)
        {
            tiempoSiguienteGolpe -= Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Mouse0) && tiempoSiguienteGolpe <= 0)
        {
            Golpear();
            tiempoSiguienteGolpe = tiempoGolpe;
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
            
    public void DañoVida(float daño)
    {
        barraVida.value -= daño;
    }
    private void Golpear()
    {
        Animator.SetTrigger("Attack");
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorGolpe.position, radioGolpe);
        foreach (Collider2D collisionador in objetos)
        {
            if (collisionador.CompareTag("Enemigos"))
            {
                collisionador.transform.GetComponent<Enemigo2D>().DañoVida(dañoEnemigo);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(controladorGolpe.position, radioGolpe);
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
            barraVida.value -= 5f;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bandera")
        {
            Time.timeScale = 0f;
            UIPause.SetActive(false);
            btnPause.SetActive(false);
            barraVidaC.SetActive(false);
            UIVictoria.SetActive(true);
        }
    }

    public void Rebote()
    {
        Rigidbody2D.velocity = new Vector2(Rigidbody2D.velocity.x, velocidadRebote);
    }



}
