using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class CameraBehavior : MonoBehaviour
{
    public GameObject player;
    float yHeight = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //camera should be centered on overhead position above player
        UnityEngine.Vector3 temp = player.transform.position;
        temp.y = yHeight; //height should be constant
        transform.position = temp;
    }
}
