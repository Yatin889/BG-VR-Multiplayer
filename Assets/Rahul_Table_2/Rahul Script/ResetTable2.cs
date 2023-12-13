using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ResetTable2 : MonoBehaviour
{
    public GameObject[] Blocks;

    [HideInInspector]
    public List<Vector3> BlocksDefaultPosition;
    [HideInInspector]
    public List<Quaternion> BlocksDefaultRotation;
    public UnityEvent onActivate;
    public UnityEvent onDeactivate;
    private void Start()
    {
        for (int i = 0; i < Blocks.Length; i++)
        {
            BlocksDefaultPosition.Add(Blocks[i].transform.position);
            BlocksDefaultRotation.Add(Blocks[i].transform.rotation);
        }
    }

    public void ResetTable()
    {
        for (int i = 0; i < Blocks.Length; i++)
        {
            Blocks[i].GetComponent<Animator>().applyRootMotion = true;
           

            Blocks[i].GetComponent<Animator>().SetBool("Play", false);
          

            Blocks[i].GetComponent<Animator>().enabled = false;
           

            Blocks[i].transform.position = BlocksDefaultPosition[i];
            Blocks[i].transform.rotation = BlocksDefaultRotation[i];

            Blocks[i].transform.parent = null;

            Blocks[i].GetComponent<Collider>().enabled = true;
          
            
        }
        onActivate.Invoke();
    }

   
}
