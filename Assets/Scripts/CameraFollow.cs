using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] int ForwardSpeed;
    void LateUpdate()
    {
        if (Variables.FirstTouch == 1)
        {
            transform.position += new Vector3(0, 0, ForwardSpeed * Time.deltaTime);
        }     
    }
}
