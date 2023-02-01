using UnityEngine;

public class SunController : MonoBehaviour
{
    public float rotationSpeed = 20;

    void Update()
    {
        transform.Rotate(0 , rotationSpeed * Time.deltaTime, 0);

    }
}
