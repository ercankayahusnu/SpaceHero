using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotater : MonoBehaviour
{
    Rigidbody physic;
    // Start is called before the first frame update
    void Start()
    {
        physic = GetComponent<Rigidbody>();

       
        physic.angularVelocity = Random.insideUnitSphere;


    }
}
