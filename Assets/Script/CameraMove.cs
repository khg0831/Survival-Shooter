using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject target;       
    public float speed = 5.0f;  
    private Vector3 vec;         

    private void Start()
    {
        vec = transform.position - target.transform.position;
    }

    public void Update()
    {
        Vector3 newCamPos = target.transform.position + vec;
        transform.position = Vector3.Lerp(transform.position, newCamPos, speed * Time.deltaTime);
    }
}
