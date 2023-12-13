using UnityEngine;
using UnityEngine.Events;


public class RotateAndTrigger : MonoBehaviour
{
    public Snap_Table2[] snapTable2;
    [Space]
    public Vector3 offRotation;
    public Vector3 onRotation;

    public float threshold = 0.5f;

    public bool isLeverOn = false;
    public bool doLog = false;

    public UnityEvent turnedOn;
    public UnityEvent turnedOff;

    public void Update()
    {
        Vector3 currentRotation = transform.localEulerAngles;
        if(Vector3.Distance(currentRotation, offRotation) <= threshold && isLeverOn)
        {
            isLeverOn = false;

            if (snapTable2[0].isSnap && snapTable2[1].isSnap)
            {
                turnedOff.Invoke();
            }
            // Debug.Log("Level off");
        }

        if (Vector3.Distance(currentRotation, onRotation) <= threshold && !isLeverOn)
        {
            isLeverOn = true;

            if(snapTable2[0].isSnap && snapTable2[1].isSnap)
            {
                snapTable2[0].DisbaleCollider();
                snapTable2[1].DisbaleCollider();
                turnedOn.Invoke();
            }         
           // Debug.Log("Level on");
        }

        if(doLog)
            Debug.Log(transform.localEulerAngles);
    }
}
