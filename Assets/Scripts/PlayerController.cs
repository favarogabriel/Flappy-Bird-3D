using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;
using UnityEditor.UI;
using UnityEditor.ProBuilder;
using UnityEngine.SceneManagement;

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
    [SerializeField] private TextMeshProUGUI restartScoreText;

    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject restartMenu;
    [SerializeField] private GameObject score;

    [SerializeField] private GameObject bronzeMedal;
    [SerializeField] private GameObject silverMedal;
    [SerializeField] private GameObject goldMedal;


    public bool tooHigh;

    public bool gameOver;
    public bool gameIsOn;

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
        StartGame();
        RestartGame();
    }

    private void StartGame()
    {
        if (Input.GetKeyDown(KeyCode.Space) && gameIsOn == false)
        {
            points = 0;
            scoreText.text = "0";
            startMenu.SetActive(false);
            score.SetActive(true);
            gameIsOn = true;
            playerRb.isKinematic = false;
            playerRb.velocity = new Vector3(0, jumpForce, 0);
            transform.eulerAngles = new Vector3(0, 0, 45);
            playerAudio.PlayOneShot(flap, 1.0f);
        }

        if (gameIsOn == false)
        {
            playerRb.isKinematic = true;

        }
    }

    private void OpenRestartMenu()
    {
        restartMenu.SetActive(true);
        score.SetActive(false);
        string pointsString = points.ToString();
        restartScoreText.text = pointsString;

        if(points > 19 && points < 29)
        {
            bronzeMedal.SetActive(true);
        } else if (points > 29 && points < 39)
        {
            silverMedal.SetActive(true);
        } else if (points > 39)
        {
            goldMedal.SetActive(true);
        } 
    }

    private void RestartGame()
    {
        if (restartMenu.activeSelf == true && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Jogo");
        }
    }

    private void MovePlayer()
    {
        if(Input.GetKeyDown(KeyCode.Space) && gameOver == false && tooHigh == false && gameIsOn == true)
        {
            playerRb.velocity = new Vector3(0, jumpForce, 0);
            // transform.rotation = Quaternion.Euler(0, 0, 50);
            transform.eulerAngles = new Vector3(0, 0, 45);
            playerAudio.PlayOneShot(flap, 1.0f);
        }

        if (gameOver == false && gameIsOn == true)
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

    public void AddPoint(int pointsToAdd)
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
            OpenRestartMenu();
        }
    }
}
