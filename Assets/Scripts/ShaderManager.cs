using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderManager : MonoBehaviour
{
    public Vector3 previousPos;

    public GameObject shader;
    public Material material;
    public float offset = 0;

    private void Start()
    {
        material = shader.GetComponent<MeshRenderer>().material;
        //previousPos = transform.position;
    }
    private void Update()
    {
        CheckDir();
    }

    public void CheckDir()
    {
        /*
        if (dotProduct > 0)
        {
            Debug.Log("forward");
            float offset = material.GetFloat("_Offset");
            offset += speed * Time.deltaTime;
            material.SetFloat("_Offset", offset);

        }
        else if (dotProduct < 0)
        {
            Debug.Log("backward");
            float offset = material.GetFloat("_Offset");
            offset -= speed * Time.deltaTime;
            material.SetFloat("_Offset", offset);
        }

        previousPos = transform.position;
        */

        //float offset = material.GetFloat("_Offset");
        //offset += speed * Time.deltaTime;
        
        material.SetFloat("_Offset", transform.localPosition.x * transform.localPosition.magnitude);
    }

}
