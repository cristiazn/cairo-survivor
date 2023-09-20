using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rangovison : MonoBehaviour
{
    public Animator ani;
    public enemigo enemigo;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("maximus"))
        {
           ani.SetBool("walk", false);
           ani.SetBool("run", false);
           ani.SetBool("attack", true);
           enemigo.atacando = true;
           GetComponent<BoxCollider2D>().enabled = false;            
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
