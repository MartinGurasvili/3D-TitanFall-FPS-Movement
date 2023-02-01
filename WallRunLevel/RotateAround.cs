using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    public GameObject target;
    public float rotationSpeed = 20;
    [Range(2.0f, 200.0f)]
    public float distance = 25;
    [Range(0, 100)]
    public int distanceVariationProbability = 1;
    public float movingDuration = 1;
    public float distanceOffset = 2;

    bool isMoving = false;
    float elapsedTime = 0;
    float newDistance = 0;
    float startDistance;

    void Start()
    {
        startDistance = distance;
    }

    void Update()
    {
        Vector3 newPos = (transform.position - target.transform.position).normalized * distance + target.transform.position;
        newPos.x = target.transform.position.x;
        transform.position = newPos;
        transform.RotateAround(target.transform.position, Vector3.right, rotationSpeed * Time.deltaTime);

        if(!isMoving)
        {
            int r = Random.Range(0, 101);
            if (r <= distanceVariationProbability)
            {   
                isMoving = true;
                newDistance = Random.Range(startDistance - distanceOffset, startDistance + distanceOffset);
            }
        }
        else
        {
            Move(newDistance);
        } 
    }

    void Move(float d)
    {   
        elapsedTime += Time.deltaTime;
        float t = elapsedTime / movingDuration;
        distance = Mathf.Lerp(distance, d, t);
        if(t >= 1)
        {
            isMoving = false;
            elapsedTime = 0;
        }
    }
}
