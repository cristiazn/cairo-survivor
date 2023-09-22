using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlataforma : MonoBehaviour
{
    public float velocidad;
    public Transform controladorSuelo;
    public float distancia;
    public bool movimientoDerecha;

    private Rigidbody2D rigidbody2;

    private void Start()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();   
    }

    private void FixedUpdate()
    {
        RaycastHit2D informacionSuelo = Physics2D.Raycast(controladorSuelo.position, Vector2.down, distancia);

        rigidbody2.velocity = new Vector2(velocidad, rigidbody2.velocity.y);

        if(informacionSuelo == false)
        {
            Girar();
        }


    }

    public void Girar()
    {
        movimientoDerecha = !movimientoDerecha;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        velocidad *= -1;
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(controladorSuelo.transform.position, controladorSuelo.transform.position + Vector3.down * distancia);
    }
}
