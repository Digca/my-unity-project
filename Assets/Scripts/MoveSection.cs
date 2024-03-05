using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSection : MonoBehaviour
{
    [SerializeField] private float speed;
    
    void FixedUpdate()
    {
        transform.position += new Vector3(0, 0, -1 * speed) * Time.deltaTime;
    }
}
