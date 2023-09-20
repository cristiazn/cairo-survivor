using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerascrip : MonoBehaviour
{
    public GameObject maximus;
        
    

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        position.x = maximus.transform.position.x;
        transform.position = position;
    }
}
