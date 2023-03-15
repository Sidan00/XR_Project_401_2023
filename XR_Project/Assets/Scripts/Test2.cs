using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test2 : MonoBehaviour
{
    public int hp = 180;
    public Text textHpUI;   //Hp UI 표시 선언
    public Text textStateUI;    //State UI 표시 선언
    // Start is called before the first frame update
    void Start()
    {
        // if(hp <= 50)
        // {
        //     Debug.Log("도망!");
        // }
        // else if(hp>=200)
        // {
        //     Debug.Log("공격!");
        // }
        // else
        // {
        //     Debug.Log("방어!");            
        // }
    }

    // Update is called once per frame
    void Update()
    {
//--------------------------------------------------
//UI 내용
//--------------------------------------------------        
        textHpUI.text = hp.ToString();

        if(hp <= 50)
        {
            textStateUI.text = "Run!";
        }
        else if(hp>=200)
        {
            textStateUI.text = "Attack!";
        }
        else
        {
            textStateUI.text = "Defance!";  
        }        
//--------------------------------------------------
//Input 내용
//--------------------------------------------------
        if(Input.GetMouseButtonDown(0)){    //마우스 왼쪽 버튼
            hp+=10;
        }

        if(Input.GetMouseButtonDown(1)){    //마우스 오른쪽 버튼
            hp-=10;
        }        
    }
}
