using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEnemigo2D : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.CompareTag("maximus"))
        {
            coll.transform.GetComponent<movimiento>().DañoVida(0.1f);
        }
    }

}
