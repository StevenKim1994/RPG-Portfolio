using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectScript : MonoBehaviour
{
    [SerializeField] Sprite[] PirateSKILL = new Sprite[3]; // 해적스킬 아이콘들
    [SerializeField] GameObject[] BabarianSKILL = new GameObject[3];
    [SerializeField] GameObject[] WizardSKILL = new GameObject[3];
    [SerializeField]
    GameObject UIinitiliazer;

    [SerializeField]
    GameObject[] Managers = new GameObject[10]; // 0: Scene ,1 : Inventory ,2 : Data ,3: Player ,4 : Interface ,5 : Skill , 6: Game

    delegate void SaveJob(string _in);
    delegate string LoadJob();
    delegate void ChangeScene();
    delegate void ui_setting();

    private SaveJob sj;
    private LoadJob lj;
    private PlayerManagerScripts PM;
    private SceneManagerScript SM;
    [SerializeField]
    Camera camera;

    [SerializeField]
    GameObject job;

    [SerializeField]
    GameObject[] skill = new GameObject[3]; // 0 : 1번스킬  1 : 2번 스킬 2 : 3번 스킬 버튼들 ...

    [SerializeField]
    GameObject skill_description;

    [SerializeField]
    InputField nickname;



    int count = 0;
    Vector3 initPosition;

    [SerializeField]
    GameObject previous;

    [SerializeField]
    GameObject next;

    void Start()
    {


        PM = Managers[(int)Enum.Managerlist.Player].GetComponent<PlayerManagerScripts>();
        SM = Managers[(int) Enum.Managerlist.Scene].GetComponent<SceneManagerScript>();

        initPosition.x = -9.16f; // 카메라의 초기값 ( 캐릭터를 바라보는 위치 )
        initPosition.y = 2.33f;
        initPosition.z = 0.58f;
        job.GetComponent<Text>().text = "해적";

        for (int i = 0; i < 3; i++)
            skill[i].transform.GetComponent<Image>().sprite = PirateSKILL[i];

        skill_description.transform.GetComponent<Text>().text = "기본적인 해적의 근접공격 스킬, 연속으로 사용시 연타모션을 취한다.";

        camera.transform.position = initPosition;

        previous.gameObject.SetActive(false);


    }

    public void nextPosition()
    {
        previous.gameObject.SetActive(true);
        camera.transform.position += new Vector3(4.5f, 0f, 0f);
        count++;

        switch (count)
        {
            case 0:
                job.GetComponent<Text>().text = "해적";
                skill_description.transform.GetComponent<Text>().text = "기본적인 해적의 근접공격 스킬, 연속으로 사용시 연타모션을 취한다.";

                break;

            case 1:
                job.GetComponent<Text>().text = "바바리안";
                skill_description.transform.GetComponent<Text>().text = "기본적인 해적의 근접공격 스킬, 연속으로 사용시 연타모션을 취한다.";

                break;

            case 2:
                job.GetComponent<Text>().text = "메이지";
                break;
        }



        if (count == 2)
        {
            next.gameObject.SetActive(false); // 버튼 비활성화
        }
        else
        {
            next.gameObject.SetActive(true);
        }


    }

    public void previousPosition()
    {

        next.gameObject.SetActive(true);
        camera.transform.position -= new Vector3(4.5f, 0f, 0f);
        count--;

        switch (count)
        {
            case 0:
                job.GetComponent<Text>().text = "해적";
                break;

            case 1:
                job.GetComponent<Text>().text = "바바리안";
                break;

            case 2:
                job.GetComponent<Text>().text = "메이지";
                break;
        }

        if (count == 0)
        {
            previous.gameObject.SetActive(false); //버튼 비활성화
        }
        else
        {
            previous.gameObject.SetActive(true);
        }

    }

    public void selectbtn()
    {

        UIinitiliazer.GetComponent<UIInitialize>().UISetOn();
        switch (count)
        {
            case 0 :
                sj = PM.Save_Job;

                sj("Pirate");
                Managers[(int)Enum.Managerlist.Player].GetComponent<PlayerManagerScripts>().Save_HP(100);//PlayerManager 에서 기본 데이터 설정하는 함수 추가해야함!!! 19.11.07
                Managers[(int)Enum.Managerlist.Player].GetComponent<PlayerManagerScripts>().Save_MP(100);
                Managers[(int)Enum.Managerlist.Player].GetComponent<PlayerManagerScripts>().Save_Damage(15);
                Managers[(int)Enum.Managerlist.Player].GetComponent<PlayerManagerScripts>().Save_Armor(10);
                Managers[(int)Enum.Managerlist.Player].GetComponent<PlayerManagerScripts>().Save_DEX(1);
                Managers[(int)Enum.Managerlist.Player].GetComponent<PlayerManagerScripts>().Save_INT(2);
                Managers[(int)Enum.Managerlist.Player].GetComponent<PlayerManagerScripts>().Save_STR(3);
                break;

            case 1:
                sj = PM.Save_Job;
                sj("Barbarian");
                break;

            case 2:
                sj = PM.Save_Job;
                sj("Wizard");
                break;
        }

        Managers[3].transform.GetComponent<PlayerManagerScripts>().Save_Name(nickname.text);


        SM.EnterStartChurch();

        // FadeIn 후 씬이동... 추가하기...
    }

    public void SKILL1INFO()
    {
       switch(count)
        {
            case 0:
                skill_description.transform.GetComponent<Text>().text = "기본적인 해적의 근접공격 스킬, 연속으로 사용시 연타모션을 취한다.";
                break;

            case 1:
                skill_description.transform.GetComponent<Text>().text = "기본적인 바바리안의 근접공격 스킬";
                break;

            case 2:
                skill_description.transform.GetComponent<Text>().text = "마법사의 기본 공격 스킬";
                break;

        }
    }

    public void SKILL2INFO()
    {
        switch (count)
        {
            case 0:
                skill_description.transform.GetComponent<Text>().text = "해적의 버프스킬, 10초간 이동속도를 3만큼 증가시킨다. 마나 20 소모";
                break;

            case 1:
                skill_description.transform.GetComponent<Text>().text = "바바리안의 버프스킬";
                break;

            case 2:
                skill_description.transform.GetComponent<Text>().text = "마법사의 버프스킬";
                break;

        }
    }

    public void SKILL3INFO()
    {
        switch (count)
        {
            case 0:
                skill_description.transform.GetComponent<Text>().text = "해적의 원거리 스킬, 지정한 대상에게 독폭탄을 던진다. 마나 10 소모";
                break;

            case 1:
                skill_description.transform.GetComponent<Text>().text = "바바리안의 버프스킬";
                break;

            case 2:
                skill_description.transform.GetComponent<Text>().text = "마법사의 버프스킬";
                break;


        }
    }

    public void POWERUPSKILL()
    {
        switch (count)
        {
            case 0:
                skill_description.transform.GetComponent<Text>().text = "분노하여 데미지 상승. 마나 10 소모";
                break;

            case 1:
                skill_description.transform.GetComponent<Text>().text = "바바리안의 버프스킬";
                break;

            case 2:
                skill_description.transform.GetComponent<Text>().text = "마법사의 버프스킬";
                break;


        }
    }

    public void FINALSKILLINFO()
    {
        switch (count)
        {
            case 0:
                skill_description.transform.GetComponent<Text>().text = "해적의 궁극기 지정한 대상에게 폭격. 마나 50 소모";
                break;

            case 1:
                skill_description.transform.GetComponent<Text>().text = "바바리안의 버프스킬";
                break;

            case 2:
                skill_description.transform.GetComponent<Text>().text = "마법사의 버프스킬";
                break;


        }
    }
}
