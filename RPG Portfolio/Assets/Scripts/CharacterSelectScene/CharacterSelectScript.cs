using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectScript : MonoBehaviour
{
    [SerializeField]
    GameObject[] Managers = new GameObject[10]; // 0: Game  1: Data  2: Scene   3:Inventory  4: Skill   5:Interface   6:Player
    [SerializeField]
    Camera camera;

    [SerializeField]
    GameObject job;

    [SerializeField]
    GameObject[] skill = new GameObject[3]; // 0 : 1번스킬  1 : 2번 스킬 2 : 3번 스킬

    [SerializeField]
    GameObject skill_description;

    [SerializeField]
    GameObject nickname;

    

    int count = 0;
    Vector3 initPosition;

    [SerializeField]
    GameObject previous;

    [SerializeField]
    GameObject next;

    void Start()
    {
        initPosition.x = -9.16f; // 카메라의 초기값 ( 캐릭터를 바라보는 위치 )
        initPosition.y = 2.33f;
        initPosition.z = 0.58f;
        job.GetComponent<Text>().text = "해적";
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
                
                break;

            case 1:
                job.GetComponent<Text>().text = "바바리안";
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
        switch (count)
        {
            case 0:
                //Managers[6].GetComponent<PlayerManagerScripts>().Save_Name(nickname.GetComponent<Text>().text.ToString());
                Managers[6].GetComponent<PlayerManagerScripts>().Save_Job("Pirate");
                break;

            case 1:
                //Managers[6].GetComponent<PlayerManagerScripts>().Save_Name(nickname.GetComponent<Text>().text.ToString());
                Managers[6].GetComponent<PlayerManagerScripts>().Save_Job("Barbarian");
                break;

            case 2:
                //Managers[6].GetComponent<PlayerManagerScripts>().Save_Name(nickname.GetComponent<Text>().text.ToString());
                Managers[6].GetComponent<PlayerManagerScripts>().Save_Job("Mage");
                break;
        }


        Managers[2].GetComponent<SceneManagerScript>().EnterStartChurch();
        // FadeIn 후 씬이동... 추가하기...
    }
}
