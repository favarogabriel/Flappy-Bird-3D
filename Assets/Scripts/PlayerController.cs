using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private AudioSource playerAudio;

    [SerializeField] private AudioClip die;
    [SerializeField] private AudioClip flap;
    [SerializeField] private AudioClip hit;
    [SerializeField] private AudioClip point;
    [SerializeField] private AudioClip swosh;

    [SerializeField] private float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAudio = GameObject.Find("Main Camera").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();  
    }

    private void MovePlayer()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.velocity = new Vector3(0, jumpForce, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pipe"))
        {
            PlayerDie();
        } else if (other.gameObject.CompareTag("Middle Collider"))
        {
            AddPoint();
        }
    }

    private void AddPoint()
    {
        playerAudio.PlayOneShot(point, 1.0f);
    }

    private void PlayerDie()
    {
        playerAudio.PlayOneShot(die, 1.0f);
    }
}
