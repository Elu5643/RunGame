using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] Player player;


    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
    }
}
