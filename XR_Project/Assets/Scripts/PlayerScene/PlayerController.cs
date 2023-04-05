using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 6;
    public GameObject PlayerPivot;
    public Camera viewCamera;
    public Vector3 velocity;
    public ProjecttileController projecttileController;

    // Start is called before the first frame update
    void Start()
    {
        viewCamera = Camera.main;       //스크립트가 시작될 때 카메라를 받아온다.
    }

    // Update is called once per frame
    void Update()
    {
        //화면에서 -> 게임 3d공간 좌표를 뽑아낸다.
        Vector3 mousePos = viewCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, viewCamera.transform.position.y));

        Vector3 targetPosition = new Vector3(mousePos.x, transform.position.y, mousePos.z);

        //피봇이 해당 타겟을 보게한다.
        PlayerPivot.transform.LookAt(targetPosition, Vector3.up);

        //방향키를 통해서 이동 벡터값을 생성한다.
        velocity = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxis("Vertical")).normalized * moveSpeed;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 10.0f, ForceMode.Impulse);
        }

        if (Input.GetMouseButtonDown(0))
        {
            projecttileController.FireProjectile();
        }
    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + velocity * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
    }
}
