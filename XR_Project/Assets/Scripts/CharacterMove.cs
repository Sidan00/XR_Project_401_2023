using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public float characterSpeed = 0;
    public GameObject characerRender;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Fade());
    }

    private void StartCoroutine(IEnumerable enumerable)
    {
        throw new NotImplementedException();
    }

    IEnumerator Fade()
    {
        Color c = characerRender.GetComponent<Renderer>().material.color;

        for(float fadeoffset = 1.0f; fadeoffset >= 0; fadeoffset -= 0.1f)
        {
            c.b = fadeoffset;
            c.g = fadeoffset;
            characerRender.GetComponent<Renderer>().material.color = c;
            yield return new WaitForSeconds(1.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            characterSpeed = 5.0f;
        }

        transform.Translate(0, 0, characterSpeed * Time.deltaTime);

        characterSpeed *= 0.99f;
        
    }
}
