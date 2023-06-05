using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField] Transform playerPosition;
    private Vector3 offSet;

    // Start is called before the first frame update
    void Start()
    {
        offSet = new Vector3(-4.23f, 0, -10.87f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        transform.position = playerPosition.position + offSet;
    }
}
