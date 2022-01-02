using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform pTransform;
    private Vector3 offset;
    private float timetoFollow = 5f;
    
    void Start()
    {
        offset = transform.position - pTransform.position;
    }
    
    private void LateUpdate()
    {
       Vector3 targetpos = pTransform.position + offset;
       transform.position = Vector3.Lerp(transform.position, targetpos, timetoFollow);  
       transform.LookAt(pTransform.position);
    }
}
