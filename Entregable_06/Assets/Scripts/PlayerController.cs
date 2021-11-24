using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    private AudioSource playerAudioSource;
    private AudioSource cameraAudioSource;
    private float verticalInput;
    public float speed = 10f;
    public float gravityModifier = 1;
    public bool gameOver;
    public ParticleSystem explosionParticleSystem;
    public AudioClip explosionClip;
    private float upperLimit = 13.5f;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerAudioSource = GetComponent<AudioSource>();
        cameraAudioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * Time.deltaTime * speed * verticalInput);

        if (transform.position.x > upperLimit)
        {
            transform.position = new Vector3(transform.position.x, upperLimit, transform.position.z);
        }
    }
}
