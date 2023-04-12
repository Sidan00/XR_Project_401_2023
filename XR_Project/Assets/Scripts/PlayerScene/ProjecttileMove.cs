using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjecttileMove : MonoBehaviour
{
    public Vector3 launchDirection;         //�߻� ����

    private void FixedUpdate()
    {
        float moveAmount = 3 * Time.fixedDeltaTime;     //�̵��ӵ� ����
        transform.Translate(launchDirection * moveAmount);  //Translate�� �̵�
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if(collision.gameObject.tag == "Object")        // tag���� Object �� ���
        {
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "Monster")        // tag���� Monster �� ���
        {
            Destroy(this.gameObject);
            collision.gameObject.GetComponent<Monster>().Damaged(1);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Monster"))
        {
            Destroy(this.gameObject);
            other.gameObject.GetComponent<Monster>().Damaged(1);
        }
    }
}
