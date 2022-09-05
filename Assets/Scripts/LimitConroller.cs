using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitConroller : MonoBehaviour
{
    [SerializeField] private Transform LimitRight;
    [SerializeField] private Transform LimitLeft;
    [SerializeField] private Transform LimitBack;
    [SerializeField] private Transform LimitForwed;

    private void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.z = Mathf.Clamp(viewPos.z, LimitBack.transform.position.z, LimitForwed.transform.position.z);
        viewPos.x = Mathf.Clamp(viewPos.x, LimitRight.transform.position.x, LimitLeft.transform.position.x);
        transform.position = viewPos;
    }
}
