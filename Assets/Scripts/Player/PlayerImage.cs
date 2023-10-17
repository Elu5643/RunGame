using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerImage : MonoBehaviour
{
    float angle = 1;

    // Update is called once per frame
    void Update()
    {
        transform.rotation *= Quaternion.AngleAxis(angle, Vector3.back);
    }
}
