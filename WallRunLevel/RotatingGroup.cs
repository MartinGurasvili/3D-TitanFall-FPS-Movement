using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingGroup : MonoBehaviour
{
    public float rotationSpeed = 20;
    [Range(0, 100)]
    public int distanceVariationProbability = 1;
    public float movingDuration = 1;
    public float distanceOffset = 2;

    List<Transform> children;
    List<float> startPositionsZ;
    List<float> currentPositionsZ;
    List<float> targetPositionsZ;
    
    bool isMoving = false;
    float elapsedTime = 0;

    void Start()
    {
        children = new List<Transform>();
        startPositionsZ = new List<float>();

        foreach (Transform t in transform)
        {
            children.Add(t);
            startPositionsZ.Add(t.localPosition.z);
        }
    }

    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime ,0 ,0);

        if(!isMoving)
        {
            int r = Random.Range(0, 101);
            if(r <= distanceVariationProbability)
            {
                isMoving = true;
                currentPositionsZ = GetCurrentPositionsZ();
                targetPositionsZ = CreateRandomDistances();
            }
        }
        else
        {
            Move();
        } 
    }

    List<float> GetCurrentPositionsZ()
    {
        List<float> dist = new List<float>();
        foreach (Transform c in children)
        {
            dist.Add(c.localPosition.z);
        }
        return dist;
    }

    List<float> CreateRandomDistances()
    {
        List<float> dist = new List<float>();
        foreach (float z in startPositionsZ)
        {
            dist.Add(Random.Range(z - distanceOffset, z + distanceOffset));
        }
        return dist;
    }

    void Move()
    {   
        elapsedTime += Time.deltaTime;
        float t = elapsedTime / movingDuration;
        
        for(int i=0; i<children.Count; i++){
            Vector3 pos = children[i].localPosition;
            pos.z = Mathf.Lerp(currentPositionsZ[i], targetPositionsZ[i], t);
            children[i].localPosition = pos;
        }

        if(t >= 1)
        {
            isMoving = false;
            elapsedTime = 0;
        }
    }
}
