using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitJugador : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("enemigos"))
        {
            coll.transform.GetComponent<Enemigo2D>().DañoVida(1);
        }
    }
}
