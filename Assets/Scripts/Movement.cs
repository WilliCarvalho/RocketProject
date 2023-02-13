using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float mainThrust;
    [SerializeField] private float rotateThrust;

    private AudioSource audio;
    private Rigidbody rigidBody;


    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidBody.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            if (!audio.isPlaying)
            {
                audio.Play();
            }
        }
        else
        {
            audio.Stop();
        }
    }

    private void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            AddRotation(rotateThrust);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            AddRotation(-rotateThrust);
        }
    }

    private void AddRotation(float rotationValue)
    {
        rigidBody.freezeRotation = true; //Freeze rotation to manually rotate
        transform.Rotate(Vector3.forward * rotationValue * Time.deltaTime);
        rigidBody.freezeRotation = false;
    }
}
