using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boolOnOffForAnimator : MonoBehaviour
{
    public GameObject reflactionprob;
    public Transform EnvironmentPos;
    [Space]
    public GameObject[] EarthReset;
    [Space]
    public GameObject[] MoonReset;
    [Space]
    public GameObject moon, earth;

    public GameObject table3_Prefab_Moon, table3_Prefab_Earth, table2_Prefab_Earth, table2_Prefab_Moon, table1_Prefab_Earth, table1_Prefab_Moon,resetEarth, resetMoon;

    public bool isRotate;

    bool isMoonRotate, isEarthRotate;

    Vector3 LastMoonPos, LastEarthPos;

    int MoonPosValue, EarthPosValue;

    public Blinker blinkerRef;

    public GameObject EnvironmentSphere;
    public Material earthEnv, moonEnv;

    public ChangePhysicsMaterial[] changePhyMaterialRef;

    public AudioSource clips;
    public AudioClip clip;

    public GameObject fadInOut;

    private void Start()
    {
        isRotate = true;

        if(PlayerPrefs.GetInt("Environment") == 0)
        {
            earth.GetComponent<Collider>().enabled = false;
            earth.transform.position = transform.position;
            earth.GetComponent<Animator>().enabled = true;
            earth.GetComponent<Animator>().applyRootMotion = true;
            isMoonRotate = true;

            moon.GetComponent<Collider>().enabled = true;
            moon.transform.position = EnvironmentPos.position;
            moon.GetComponent<Animator>().enabled = false;
        }
        else if (PlayerPrefs.GetInt("Environment") == 1)
        {
            moon.GetComponent<Collider>().enabled = false;
            moon.transform.position = transform.position;
            moon.GetComponent<Animator>().enabled = true;
            moon.GetComponent<Animator>().applyRootMotion = true;
            isEarthRotate = true;

            earth.GetComponent<Collider>().enabled = true;
            earth.transform.position = EnvironmentPos.position;
            earth.GetComponent<Animator>().enabled = false;
        }
    }
    private void Update()
    {
        if(isRotate)
        {
            RotateObject();
        } 
        else
        {
            if(MoonPosValue < 1 && isMoonRotate)
            {
                LastMoonPos = moon.transform.position;
                MoonPosValue++;
            }

            if (EarthPosValue < 1 && isEarthRotate)
            {
                LastEarthPos = earth.transform.position;
                EarthPosValue++;
            }
        }
    }
    IEnumerator LerpToCenter(GameObject obj, Material mat)
    {
        float t = 0;

        while(t < 1)
        {
            t += Time.deltaTime * .5f;

            obj.transform.position = Vector3.Lerp(new Vector3(0, 1f, 0), transform.position, t);
            obj.transform.rotation = Quaternion.Lerp(obj.transform.rotation, Quaternion.Euler(Vector3.zero), Time.deltaTime * .2f);

            if(t > 0.85f)
            {
                reflactionprob.SetActive(false);
                EnvironmentSphere.GetComponent<Renderer>().material = mat;
            }
            if (t > 0.9f)
            {
                reflactionprob.SetActive(true);
            }

            yield return null;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Moon")
        {
            foreach(GameObject obj in MoonReset)
            {
                obj.SetActive(true);
            }

            isMoonRotate = false;
            PlayerPrefs.SetInt("Environment", 1);
            
            earth.GetComponent<Animator>().applyRootMotion = false;
            moon.GetComponent<Collider>().enabled = false;

            StartCoroutine(LerpToCenter(moon, moonEnv));

            earth.GetComponent<Animator>().Play("EarthSlide");

            StartCoroutine(WaitForSlide(earth, true, false));

            other.GetComponent<HapticContinue>().SingleHaptcCall();

            blinkerRef.blinkThreePhase(1, 0.5f, 1);

            clips.PlayOneShot(clip);

            for(int i=0; i<changePhyMaterialRef.Length; i++)
            {
                changePhyMaterialRef[i].GetComponent<ChangePhysicsMaterial>().PhysicsValueOnMoon();
                table3_Prefab_Moon.SetActive(true);
                table3_Prefab_Earth.SetActive(false);
                fadInOut.SetActive(true);

                table2_Prefab_Moon.SetActive(true);
                table2_Prefab_Earth.SetActive(false);

                table1_Prefab_Moon.SetActive(true);
                table1_Prefab_Earth.SetActive(false);

                resetMoon.SetActive(true);
                resetEarth.SetActive(false);

            }
          
        }

        if (other.tag == "Earth")
        {
            foreach (GameObject obj in EarthReset)
            {
                obj.SetActive(true);
            }

            isEarthRotate = false;
            PlayerPrefs.SetInt("Environment", 0);

            moon.GetComponent<Animator>().applyRootMotion = false;
            earth.GetComponent<Collider>().enabled = false;

            StartCoroutine(LerpToCenter(earth, earthEnv));

            moon.GetComponent<Animator>().Play("MoonSlide");
        
            StartCoroutine(WaitForSlide(moon, false, true)); 
            
            other.GetComponent<HapticContinue>().SingleHaptcCall();

            blinkerRef.blinkThreePhase(1, 0.5f, 1);

            clips.PlayOneShot(clip);

            for (int i = 0; i < changePhyMaterialRef.Length; i++)
            {
                changePhyMaterialRef[i].GetComponent<ChangePhysicsMaterial>().PhysicsValueOnEarth();
                table3_Prefab_Moon.SetActive(false);
                table3_Prefab_Earth.SetActive(true);
                fadInOut.SetActive(true);

                table2_Prefab_Moon.SetActive(false);
                table2_Prefab_Earth.SetActive(true);

                table1_Prefab_Moon.SetActive(false);
                table1_Prefab_Earth.SetActive(true);

                resetEarth.SetActive(true);
                resetMoon.SetActive(false);
            }           

        }
    }
    IEnumerator WaitForSlide(GameObject obj, bool isEarth, bool isMoon)
    {
        yield return new WaitForSeconds(2.5f);

        if(isEarth)
        {
            moon.GetComponent<Animator>().enabled = true;
            moon.GetComponent<Animator>().applyRootMotion = true;
            isEarthRotate = true;
        }

        if(isMoon)
        {
            earth.GetComponent<Animator>().enabled = true;
            earth.GetComponent<Animator>().applyRootMotion = true;
            isMoonRotate = true;
        } 

        obj.GetComponent<Collider>().enabled = true;
        obj.GetComponent<Animator>().enabled = false;
    }
    public void RotateObject()
    {
        if(isMoonRotate)
        {
            moon.transform.RotateAround(transform.position, Vector3.up, -1f);
        }
        
        if(isEarthRotate)
        {
            earth.transform.RotateAround(transform.position, Vector3.up, -1f);
        }
    }

    public void RotationManage(bool value)
    {
        isRotate = value;

        if(value && isMoonRotate)
        {
            moon.transform.position = LastMoonPos;
            MoonPosValue = 0;
        }

        if (value && isEarthRotate)
        {
            earth.transform.position = LastEarthPos;
            EarthPosValue = 0;
        }
    }
}
