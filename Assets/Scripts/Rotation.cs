using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public bool isLeftRotate = false;
    public bool isRightRotate = false;
    public float speed;

    void Update()
    {

        if (isLeftRotate)
        {
            transform.Rotate(Vector3.forward, speed * Time.deltaTime);
        }

        else if (isRightRotate)
        {
            transform.Rotate(-Vector3.forward, speed * Time.deltaTime);
        }



       
    }
}
