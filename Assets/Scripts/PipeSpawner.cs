using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject pipe;
    [SerializeField] private float spawnRate;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnPipe", 0, spawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnPipe()
    {
        float maxHeight = 6.5f;
        float minHeight = 0.0f;
        if (playerControllerScript.gameOver == false)
        {
            float randomHeight = Random.Range(minHeight, maxHeight);

            Vector3 spawnPos = new Vector3(36, randomHeight, 15.55f);
            Instantiate(pipe, spawnPos, pipe.transform.rotation);
        }
    }
}
