using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntScrip : MonoBehaviour
{
public GameObject maximus;

  private void Update()
   {
    Vector3 direction = maximus.transform.position - transform.position;
    if (direction.x >=0.0f) transform.localScale = new Vector3 (10f, 10f, 10f);
    else transform.localScale = new Vector3(-10f, 10f, 10f);
    
    float distance = Mathf.Abs(maximus.transform.position.x - transform.position.x);
 }
}
