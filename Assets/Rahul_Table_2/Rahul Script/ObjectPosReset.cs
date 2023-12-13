using BNG;
using System.Collections;
using UnityEngine;

public class ObjectPosReset : GrabbableEvents
{
    public LeverEventTable2 LET;
    [Space]
    public Transform Parent;

    public Transform Target;
    public Transform Target2;

    public GameObject Highlight;
   // public GameObject FirstCanvas;

    Vector3 DefaultPos, DefaultRot;

    private void OnEnable()
    {
      //  transform.parent = Parent;
        DefaultPos = transform.position;
        DefaultRot = transform.eulerAngles;
    }

    private void OnDisable()
    {
      //  transform.parent = Parent;
        transform.position = DefaultPos;
        transform.eulerAngles = DefaultRot;
        LET.LeverOffEvent.Invoke();
    }

    public override void OnGrab(Grabber grabber)
    {
        Highlight.SetActive(false);
        if(Target.childCount > 1 && transform.parent == Target || Target2.childCount > 1 && transform.parent == Target2)
        {
            Highlight.SetActive(true);
        }
        StartCoroutine(WaitForNullParent());
    }

    IEnumerator WaitForNullParent()
    {
        yield return new WaitForSeconds(.2f);
        if (Target.childCount == 1)
        {
            Target.GetComponent<Snap_Table2>().FalseBoolean();
            Target.GetComponent<DisaableAfterDelay>().enabled = true;
        }

        if (Target2.childCount == 1)
        {
            Target2.GetComponent<Snap_Table2>().FalseBoolean();
            Target2.GetComponent<DisaableAfterDelay>().enabled = true;
        }
    }
    public override void OnRelease()
    {
        if (Vector3.Distance(transform.position, Target.position) > .1f || Vector3.Distance(transform.position, Target2.position) > .1f)
        {
            transform.position = DefaultPos;
            transform.eulerAngles = DefaultRot;
            transform.parent = null;

            Highlight.SetActive(true);
        }

        Target.GetChild(0).gameObject.SetActive(false);
        Target2.GetChild(0).gameObject.SetActive(false); 
    }

    public void resetParent()
    {
        transform.parent = Parent;
    }
}
