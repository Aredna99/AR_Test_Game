using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    int rndXRot;
    int rndYRot;
    int rndZRot;
    // Start is called before the first frame update
    void Start()
    {
        rndXRot = Random.Range(1, 60);
        rndYRot = Random.Range(1, 60);
        rndZRot = Random.Range(1, 60);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(rndXRot, rndYRot, rndZRot) * Time.deltaTime);
    }
}
