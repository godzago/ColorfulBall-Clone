using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sılders : MonoBehaviour
{
    [SerializeField] private Vector3 pos1;
    [SerializeField] private Vector3 pos2;
    [SerializeField] private float Speed;
    void LateUpdate()
    {
        gameObject.transform.GetComponent<Transform>().localPosition = Vector3.Lerp(pos1, pos2, 
        Mathf.PingPong(Time.time * Speed,1.0f));
    }
}
