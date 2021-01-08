//######################################
//  code writen by
//                 Martin Gurasvili
//  licence: free to use and edit 
//######################################

using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine.UI;
using UnityEngine;

public class health : MonoBehaviour
{
    public int life = 100;  //health
    public GameObject deathscreeen;  //red vignette screen - for player to know that low on health
    public Text percent;  //text with health precentage
    public float timer = 0;

    void Start()
    {
        percent.text = life + "%";
    }

    void FixedUpdate()
    {
        timer += Time.deltaTime;
    }

    void Update()
    {
        if(life <= 20)
        {
            deathscreeen.SetActive(true);
        }
        else
        {
            deathscreeen.SetActive(false);
        }
        percent.text = life + "%";

        healthregen();

        if(life <= 0)
        {
            life = 0;
        }
    }

    public void healthregen() //reganerating health after some time
    {
        if (life < 99)
        {
            if(timer >= 3)
            {
                life += 2;
                timer = 0;
            }
        }
    }
    public void takedamage(int amount) // take damage
    {
        life -= amount;
    }
}
