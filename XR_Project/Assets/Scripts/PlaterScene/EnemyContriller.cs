using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyContriller : MonoBehaviour
{

    public float speed = 5.0f;
    public float rotationSpeed = 1.0f;
    public GameObject bulletPrefab;
    public GameObject EnemyPivot;
    public Transform firePoint;
    public float fireRate = 1f;

    private Rigidbody rb;
    private Transform player;

    private float NextFireTime;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform;  //Player Tag 가지고 있는 object transform 입력
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(player.position, transform.position ) > 5.0f)
        {
            Vector3 direction = (player.position - transform.position).normalized; // 이동방향성
            rb.MovePosition(transform.position + direction * speed * Time.deltaTime);   //방향성 계산된것 Rigidbody에 반영

        }
        //포탑 회전
        Vector3 targetDirection = (player.position - EnemyPivot.transform.position).normalized; // 포탑의 방향성을 계산
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        EnemyPivot.transform.rotation = Quaternion.Lerp(EnemyPivot.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime); //계산된 회전값을 반영

        if(Time.time > NextFireTime)
        {
            NextFireTime = Time.time + 1f / fireRate;        // 시간대비 쏘는 횟수
            GameObject temp = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            temp.GetComponent<ProjectileMove>().launchDirection = firePoint.localRotation * Vector3.forward;        //발사점을 보정해주는 라인
            temp.GetComponent<ProjectileMove>().projectileType = ProjectileMove.PROJECTILETYPE.MONSTER;             //발사체 타입 설정
            Destroy(temp, 10.0f);                          //10초후에 생성된 발사체 삭제
        }
    }
}
