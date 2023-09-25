using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rebote : MonoBehaviour
{

    private int vida = 0;
    private void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("maximus"))
         {
            foreach(ContactPoint2D punto in other.contacts)
            {
                if (punto.normal.y <= -0.9)
                {
                    other.gameObject.GetComponent<movimiento>().Rebote();
                    vida += 1;
                    if (vida == 5)
                    {
                        Destroy(gameObject);
                    }
                }
            }
        }
    }
}
