using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjecttileMove : MonoBehaviour
{
    public Vector3 launchDirection;         //발사 방향

    private void FixedUpdate()
    {
        float moveAmount = 3 * Time.fixedDeltaTime;     //이동속도 설정
        transform.Translate(launchDirection * moveAmount);  //Translate로 이동
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if(collision.gameObject.tag == "Object")        // tag값이 Object 인 경우
        {
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "Monster")        // tag값이 Monster 인 경우
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
