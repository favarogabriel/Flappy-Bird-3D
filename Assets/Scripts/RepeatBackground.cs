using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    [SerializeField] private PlayerController playerControllerScript;
    [SerializeField] private float movementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        movementSpeed = 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        MoveBackground();
    }
    
    private void MoveBackground()
    {
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);

            if (transform.position.x <= -6.82f)
            {
                transform.position = new Vector3(14.90167f, -4.603445f, 30.45586f);
            }
        }
    }
}
