using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    public float speed = 2;
    int dir = 1;

    public Transform RightCheck;
    public Transform LeftCheck;

    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * dir * Time.deltaTime );

        if(Physics2D.Raycast(RightCheck.position, Vector2.down,2 ) == false)
        dir = -1;

        if(Physics2D.Raycast(LeftCheck.position, Vector2.down,2 ) == false)
        dir = 1;
    }
}
