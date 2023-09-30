using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    Transform trans;
    void Start()
    {
        trans = transform;
    }

    // Update is called once per frame
    void Update()
    {
        float _v = Input.GetAxisRaw("Vertical");
        float _h = Input.GetAxisRaw("Horizontal");

        if (_v != 0)
        {
            trans.Translate(_v * Vector3.up * 10f * Time.deltaTime);
        }

        if (_h != 0)
        {
            trans.Translate(_h * Vector3.right * 10f * Time.deltaTime);
        }

        // Vector3 mousePosition = Input.mousePosition;

        
    }
}
