using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class props : MonoBehaviour
{
    private float timerr;
    private bool colided;
    private bool policehit;
    // Start is called before the first frame update
    void Start()
    {
        colided = false;
        policehit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (colided == true)
        {
            timerr += Time.deltaTime * 1;
            if (timerr > 7)
            {
                gameObject.SetActive(false);
            }
        }
        if (colided == true)
        {
            timerr += Time.deltaTime * 1;
            if (timerr > 3)
            {
                gameObject.SetActive(true);
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            colided = true;
        }
        if(collision.gameObject.CompareTag("Enemy"))
        {
            colided = true;
        }
        if (collision.gameObject.CompareTag("Police"))
        {
            gameObject.SetActive(false);
            policehit = true;
        }
    }
}
