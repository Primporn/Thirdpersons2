using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chackwinner : MonoBehaviour
{
    public Camera defaultCamera;
    public Camera winnerCamera;
    public bool isWinner = false;

    public Transform target;
    public float smoothSpeed = 1.0f;

    public static Chackwinner instance;

    private void Awake()
    {
        instance = this; 
    }

    // Start is called before the first frame update
    void Start()
    {
        defaultCamera.enabled = true;
        winnerCamera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isWinner)
        {
            defaultCamera.enabled = false;
            winnerCamera.enabled = true;
        }
    }

    private void LateUpdate()
    {
        if(target != null && isWinner)
        {
            Vector3 desiredPosition = new Vector3(target.position.x-4, target.position.y, target.position.z);

            Vector3 smoothedPostion = Vector3.Lerp(winnerCamera.transform.position, desiredPosition
                                      , smoothSpeed* Time.deltaTime);
            winnerCamera.transform.position = smoothedPostion;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            isWinner = true;
        }
    }
}
