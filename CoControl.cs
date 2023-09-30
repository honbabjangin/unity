using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Step03
{
    public class CoControl : MonoBehaviour
    {
    IEnumerator Start()
    {
        Debug.Log("Start1");
        while (Time.time < 1f)
        {
            yield return null;  //한프레임...
            Debug.Log("Start2");
        }


        Debug.Log("Start3");
        yield return new WaitForSeconds(2f);
        Debug.Log("Start4");

        yield return StartCoroutine(Co_Wait(2f));
        Debug.Log("Start5");
    }

    IEnumerator Co_Wait(float _time)
    {
        Debug.Log("CoWait1");
        float _waitTime = _time;
        while(_waitTime > 0)
        {
            Debug.Log("CoWait2");
            _waitTime -= Time.deltaTime;
            yield return null;
        }
        Debug.Log("CoWait3");
    }

    private void Update()
    {
        Debug.Log("Update");
    }

    }

}