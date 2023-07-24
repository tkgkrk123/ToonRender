using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{

    public float DegreePerSecond;
    Vector3 ThisRotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ThisRotation = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(ThisRotation.x, ThisRotation.y + Time.deltaTime * DegreePerSecond, ThisRotation.z);
    }
}
