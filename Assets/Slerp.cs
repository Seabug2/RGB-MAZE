using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slerp : MonoBehaviour
{
    public Transform startPosition;
    public Transform endPosition;
    float t = 0;
    private void Update()
    {
        t += Time.deltaTime;
        transform.position = Vector3.Slerp(startPosition.position, endPosition.position, t);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Transform temp = startPosition;
            startPosition = endPosition;
            endPosition = temp;
            t = 0;
        }
    }
}
