using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public float characterSpeed = 0;
    public GameObject characterRender;
    void Start()
    {
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        Color c = characterRender.GetComponent<Renderer>().material.color;      //meterial ����

        for(float fadeoffset = 1.0f; fadeoffset >=0; fadeoffset -= 0.1f)
        {
            c.b = fadeoffset;       //blue �� ����
            c.g = fadeoffset;       //green �� ����
            characterRender.GetComponent<Renderer>().material.color = c;
            yield return new WaitForSeconds(1.0f);      //for ���� 1�ʸ��� ���ư��� ��
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            characterSpeed = 5.0f;
        }

        transform.Translate(0, 0, characterSpeed * Time.deltaTime);

        characterSpeed *= 0.99f;

    }
}
