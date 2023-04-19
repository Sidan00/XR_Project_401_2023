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
        player = GameObject.FindGameObjectWithTag("Player").transform;  //Player Tag ������ �ִ� object transform �Է�
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(player.position, transform.position ) > 5.0f)
        {
            Vector3 direction = (player.position - transform.position).normalized; // �̵����⼺
            rb.MovePosition(transform.position + direction * speed * Time.deltaTime);   //���⼺ ���Ȱ� Rigidbody�� �ݿ�

        }
        //��ž ȸ��
        Vector3 targetDirection = (player.position - EnemyPivot.transform.position).normalized; // ��ž�� ���⼺�� ���
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        EnemyPivot.transform.rotation = Quaternion.Lerp(EnemyPivot.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime); //���� ȸ������ �ݿ�

        if(Time.time > NextFireTime)
        {
            NextFireTime = Time.time + 1f / fireRate;        // �ð���� ��� Ƚ��
            GameObject temp = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            temp.GetComponent<ProjectileMove>().launchDirection = firePoint.localRotation * Vector3.forward;        //�߻����� �������ִ� ����
            temp.GetComponent<ProjectileMove>().projectileType = ProjectileMove.PROJECTILETYPE.MONSTER;             //�߻�ü Ÿ�� ����
            Destroy(temp, 10.0f);                          //10���Ŀ� ������ �߻�ü ����
        }
    }
}
