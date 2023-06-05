using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;
using UnityEditor.ProBuilder;

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
    [SerializeField] private int points;
    [SerializeField] private TextMeshProUGUI scoreText;
    public bool tooHigh;

    public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        points = 0;
        scoreText.text = "0";
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
        if(Input.GetKeyDown(KeyCode.Space) && gameOver == false && tooHigh == false)
        {
            playerRb.velocity = new Vector3(0, jumpForce, 0);
            // transform.rotation = Quaternion.Euler(0, 0, 50);
            transform.eulerAngles = new Vector3(0, 0, 45);
            playerAudio.PlayOneShot(flap, 1.0f);
        }

        if (gameOver == false)
        {
            transform.Rotate(0, 0, -1 * 100 * Time.deltaTime);
        }

        if (transform.position.y > 15)
        {
            tooHigh = true;
        } else
        {
            tooHigh = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pipe") || other.gameObject.CompareTag("Ground"))
        {
            PlayerDie();
        } else if (other.gameObject.CompareTag("Middle Collider"))
        {
            AddPoint(1);
        }
    }

    private void AddPoint(int pointsToAdd)
    {
        playerAudio.PlayOneShot(point, 1.0f);
        points += pointsToAdd;

        string pointsString = points.ToString();
        scoreText.text = pointsString;
    }

    private void PlayerDie()
    {
        if (gameOver == false)
        {
            playerAudio.PlayOneShot(die, 1.0f);
            gameOver = true;
        }
    }
}
