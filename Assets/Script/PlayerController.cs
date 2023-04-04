using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;

}
public class PlayerController : MonoBehaviour
{
    Rigidbody pyhsic;
    AudioSource audioPlayer;

    [SerializeField] int speed;
    [SerializeField] int tilt;
    [SerializeField] float nextFire;
    [SerializeField] float fireRate;

    public Boundary boundary;

    public GameObject shot;
    public GameObject shotSpawn;


     void Start()
    {
        
        pyhsic = GetComponent<Rigidbody>();
        audioPlayer = GetComponent<AudioSource>();
    }

     void Update()
    {
        
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            //Lazer oluþturma 
            nextFire = Time.time + fireRate ;
            Instantiate(shot, shotSpawn.transform.position, shotSpawn.transform.rotation);
            audioPlayer.Play();
        }
       
    }

     void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0 ,moveVertical );

        pyhsic.velocity = movement;

        pyhsic.velocity = movement *speed;

        Vector3 position = new Vector3(
            Mathf.Clamp(pyhsic.position.x, boundary.xMin, boundary.xMax),
            0,
             Mathf.Clamp(pyhsic.position.z, boundary.zMin, boundary.zMax)
            );

        pyhsic.position = position;

        pyhsic.rotation = Quaternion.Euler(0, 0, pyhsic.velocity.x * tilt); //Manevra sýrasýnda gemiye eðim verir.
    }
    
}
