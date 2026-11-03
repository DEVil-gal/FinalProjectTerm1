using System;
using TMPro;
using Unity.Collections.Tests.CoreCLR.TestJobs;
using UnityEditor.UI;
using UnityEngine;

public class Coin : MonoBehaviour
{

    public float RotationSpeed = 90;
    public GameObject Self;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, RotationSpeed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Self.SetActive(false);
        }
    }
}
