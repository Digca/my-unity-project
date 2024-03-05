using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionTrigger : MonoBehaviour

{
    [SerializeField] private GameObject section;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trigger"))
        {
            Instantiate(section, new Vector3(0, 0, 7.62f), Quaternion.identity);
        }
    }
}
