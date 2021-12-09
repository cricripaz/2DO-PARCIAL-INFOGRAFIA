using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject follow;
    public Vector2 minCamPosition;
    public Vector2 maxCamPosition;
    public float smoothTime;


    private Vector2 velocity;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


      float posX =   Mathf.SmoothDamp(transform.position.x, follow.transform.position.x, ref velocity.x, smoothTime);
       float posY =   Mathf.SmoothDamp(transform.position.y, follow.transform.position.y, ref velocity.y, smoothTime);

        //float posX = follow.transform.position.x;
        //float posY = follow.transform.position.y;

        transform.position = new Vector3(

            Mathf.Clamp(posX, minCamPosition.x, maxCamPosition.x), // X
            Mathf.Clamp(posY ,  minCamPosition.y,maxCamPosition.y), // Y
            transform.position.z); // Z
        ;
        
    }
}
