using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerShake : MonoBehaviour
{
    private bool SheckController = false;
   public IEnumerator CameraShake(float duration, float magnitude)
    {
        Vector3 orginalPos = transform.localPosition;

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f , 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, orginalPos.z);

            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = orginalPos;
    }

    public void CameraShakeCall()
    {
        if (SheckController == false)
        {
            StartCoroutine(CameraShake(0.12f, 0.2f));
            SheckController = true;
        }      
    }
}
