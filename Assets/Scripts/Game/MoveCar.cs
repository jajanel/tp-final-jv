using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCar : MonoBehaviour
{
    private float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.Rotate(0, 90, 0, Space.Self);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
