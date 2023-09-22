using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Daño : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("maximus"))
        {
            collision.transform.GetComponent<movimiento>().DañoVida(0.1f);
        }
    }
}
