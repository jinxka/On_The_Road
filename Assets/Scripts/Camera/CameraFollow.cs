using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    private Transform target;
    public float smoothing = 5f;

    Vector3 offset;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - target.position;     
    }

    void FixedUpdate()
    {
        Vector3 targetCamPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
