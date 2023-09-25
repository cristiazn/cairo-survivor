using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemigo2D : MonoBehaviour
{

    public int rutina;
    public float vida = 2;
    public float cronometro;
    public Animator ani;
    public int direccion;
    public float speed_walk;
    public float speed_run;
    public GameObject target;
    public bool atacando;
    public Transform controladorSuelo;
    public float distancia;
    public bool movimientoDerecha;
    public float rango_vision;
    public float rango_ataque;
    public GameObject rango;
    public GameObject Hit;
    private Rigidbody2D rigidbody2;

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        target = GameObject.Find("maximus");
        rigidbody2 = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Comportamientos();
        if(vida == 0)
        {
            Destroy(gameObject);
        }
    }

    public void Comportamientos()
    {
        RaycastHit2D informacionSuelo = Physics2D.Raycast(controladorSuelo.position, Vector2.down, distancia);

        if (Mathf.Abs(transform.position.x - target.transform.position.x) > rango_vision && !atacando )
        {
            ani.SetBool("run", false);
            cronometro += 1 * Time.deltaTime;
            if (cronometro >= 4)
            {
                rutina = Random.Range(0, 2);
                cronometro = 0;
            }
            switch (rutina)
            {
                case 0:
                    ani.SetBool("walk", false);
                    break;

                case 1:
                    direccion = Random.Range(0, 2);
                    rutina++;
                    break;

                case 2:

                    switch (direccion)
                    {
                        case 0:
                            if(informacionSuelo == false)
                            {
                                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
                            }
                            else
                            {
                                transform.Translate(Vector3.right * speed_walk * Time.deltaTime);
                            }
                            
                            break;

                        case 1:
                            if(informacionSuelo == false)
                            {
                                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
                            }
                            else
                            {
                                transform.Translate(Vector3.right * speed_walk * Time.deltaTime);
                            }
                            break;
                    }
                    ani.SetBool("walk", true);
                    break;
            }
        }
        else
        {
            if (Mathf.Abs(transform.position.x - target.transform.position.x) > rango_ataque && !atacando)
            {
               if (transform.position.x < target.transform.position.x)
               {
                    ani.SetBool("walk", false);
                    ani.SetBool("run", true);
                    transform.Translate(Vector3.right * speed_run * Time.deltaTime);
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    ani.SetBool("attack", false);
               }
               else
               {
                    ani.SetBool("walk", false);
                    ani.SetBool("run", true);
                    transform.Translate(Vector3.right * speed_run * Time.deltaTime);
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                    ani.SetBool("attack", false);
               }
            }     
            else
            {
                if (!atacando)
                {
                    if (transform.position.x < target.transform.position.x)
                    {                        
                        transform.rotation = Quaternion.Euler(0, 0, 0);                      
                    }
                    else
                    { 
                        transform.rotation = Quaternion.Euler(0, 180, 0);
                    }
                    ani.SetBool("walk", false);
                    ani.SetBool("run", false);                    
                }
            }
        }
    }

    public void Final_Ani()
    {
        ani.SetBool("attack", false);
        atacando = false;     
        rango.GetComponent<BoxCollider2D>().enabled = true;
    }
    public void ColliderWeaponTrue()
    {
        Hit.GetComponent<BoxCollider2D>().enabled = true;
    }
    public void ColliderWeaponFalse()
    {
        Hit.GetComponent<BoxCollider2D>().enabled = false;
    }
    public void DañoVida(float daño)
    {
        vida -= daño;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Caida")
        {
            Destroy(gameObject);
        }
    }
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(controladorSuelo.transform.position, controladorSuelo.transform.position + Vector3.down * distancia);
    }

}
