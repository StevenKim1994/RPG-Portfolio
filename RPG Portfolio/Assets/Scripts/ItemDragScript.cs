using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragScript : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public static Vector2 defaultposition;

    [SerializeField] private GameObject Bank;
    
    // 드래그 시작할때 호출되는 함수
    public void OnBeginDrag(PointerEventData eventData)
    {
        Bank = GameObject.Find("Bank");
        defaultposition = this.transform.position;
    }

    // 드래그 하는 중일 때 호출되는 함수
    public void OnDrag(PointerEventData eventData)
    {
        if (Bank != null)
        {

            Vector2 currentPos = Input.mousePosition;
            this.transform.position = currentPos;
            Debug.Log(this.transform.position);
            Debug.Log(Bank.transform.position);
            if (this.transform.position.x <= 700f) // 창고의 위치에 충돌됬을 때
            {
                Debug.Log("아이템넣기!");
            }
           
            
        }
    }

    // 드래그를 끝냈을때 호출되는 함수
    public void OnEndDrag(PointerEventData eventData)
    {
        Vector2 mousePos;
        if (Bank != null)
        {
            if (this.transform.position.x <= 700f) // 창고의 위치에 충돌됬을 때
            {
                Debug.Log("ㅊㅊㅊ");

                // 해당 아이템칸 빈걸로 하는 코드 추가부분






                mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                this.transform.position = defaultposition;
            }

            else
            {
                mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                this.transform.position = defaultposition;
            }
        }

       
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
