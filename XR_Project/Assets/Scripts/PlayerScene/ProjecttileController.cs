using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjecttileController : MonoBehaviour
{
    public Vector3 launchDirection;
    public GameObject Projectile;
    
    public void FireProjectile()
    {
        GameObject temp = (GameObject)Instantiate(Projectile);

        temp.transform.position = this.gameObject.transform.position;
        temp.transform.localScale = Vector3.one * 0.3f;
        temp.GetComponent<ProjecttileMove>().launchDirection = transform.forward;

        Destroy(temp, 10.0f);       // 10초 후 생성된 발사채 삭제
    }
}
