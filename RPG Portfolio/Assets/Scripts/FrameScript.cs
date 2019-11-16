using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrameScript : MonoBehaviour
{
    GameObject Managers;
    [SerializeField] GameObject hpBar;
    [SerializeField] GameObject mpBar;
    [SerializeField] GameObject portrait;
    [SerializeField] Sprite[] JobPortrait = new Sprite[5];
    ManagerSingleton MGR = new ManagerSingleton();
    void Start()
    {

        if(this.gameObject.name == "UnitFrame") // 이 스크립트가 적용된 오브젝트가 플레이어일때 ...
        {
            //this.gameObject.transform.GetChild(0); 여기서 초상화 설정해야함 나중에 여기로하는걸로 수정하기 19.10.30
            this.gameObject.transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().fillAmount = MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).GetComponent<PlayerManagerScripts>().Load_HP() * 0.01f;
            this.gameObject.transform.GetChild(2).transform.GetChild(0).GetComponent<Image>().fillAmount = MGR.Get_instance().transform.GetChild((int) Enum.Managerlist.Player).GetComponent<PlayerManagerScripts>().Load_MP() * 0.01f; //0.01f 을 곱하는 이뉴는 1일 경우 이미지가 가득채워지기 때문임.

        }

    }

    void Update()
    {


        if (this.gameObject.transform.name == "UnitFrame") // 이 스크립트가 적용된 오브젝트가 플레이어일때 ...
        {
            if (MGR.Get_instance().gameObject.transform.GetChild((int)Enum.Managerlist.Player).GetComponent<PlayerManagerScripts>().Load_Job() == "Pirate")
                gameObject.transform.GetChild(0).GetComponent<Image>().sprite = JobPortrait[0];

            //0 : Portrait , 1 : HP 2 :  MP
            this.gameObject.transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().fillAmount = MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).GetComponent<PlayerManagerScripts>().Load_HP() * 0.01f;
            this.gameObject.transform.GetChild(2).transform.GetChild(0).GetComponent<Image>().fillAmount = MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).GetComponent<PlayerManagerScripts>().Load_MP() * 0.01f; //0.01f 을 곱하는 이뉴는 1일 경우 이미지가 가득채워지기 때문임.
            this.gameObject.transform.GetChild(3).transform.GetComponent<Text>().text = MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).GetComponent<PlayerManagerScripts>().Load_Name();
        }

        else if(this.gameObject.transform.name =="TargetFrame")
        {

        }
    }
    void SetData(float _hp, float _mp)
    {

    }
}
