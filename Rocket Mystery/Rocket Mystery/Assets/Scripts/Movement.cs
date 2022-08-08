using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    AudioSource audioSource;
    Collision collision;

    [SerializeField] float moc = 1500f;
    [SerializeField] float ruch = 150f;
    [SerializeField] AudioClip silnik;
    [SerializeField] ParticleSystem dopalacz;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        collision = GetComponent<Collision>();


    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
        ProcessRotation();

    }

    void ProcessInput()
    {
        if (Input.GetKey(KeyCode.Space))
        { 
            Spacja();
        }

        else
        {
            BrakSpacji();
        }
    }

    void BrakSpacji()
    {
        audioSource.Stop();
        dopalacz.Stop();
    }

    void Spacja()
    {
        rb.AddRelativeForce(Vector3.up * Time.deltaTime * moc);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(silnik);
        }
        if (!dopalacz.isPlaying)
        {
            dopalacz.Play();
        }

    }

    void ProcessRotation()
    {
        Skret();
    }

    void Skret()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(ruch);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-ruch);
        }
    }

    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationThisFrame);
        rb.freezeRotation = false;
    }   
    
}


