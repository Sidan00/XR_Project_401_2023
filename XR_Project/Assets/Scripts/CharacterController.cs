using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // Start is called before the first frame update
    float rotSpeed = 0;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            rotSpeed = 10000;
        }

        transform.Rotate(0, rotSpeed * Time.deltaTime, 0);

        rotSpeed *= 0.99f;

    }
}
