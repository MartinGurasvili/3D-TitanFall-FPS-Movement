//######################################
//  code writen by
//                 Martin Gurasvili
//  licence: free to use and edit 
//######################################

using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

//This attaches to a bullet game object

public class bullet : MonoBehaviour
{
    public float speed = 10f; //speed of bullet
    public float timer = 0;
    public GameObject hit_effect;
 
    void Update()
    {
        timer += Time.deltaTime;

        transform.position += transform.forward * speed * Time.deltaTime; 

        if(timer > 3f)
        {
            Destroy(gameObject); // after 3 seconds the bullet automatically removes from scene
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        hit_effect.SetActive(true); // make sure hit effect is a child

        // you can also instantiate the hiteffect using   hit_effect.transform.position = gameObject.transform.position
    }
}
