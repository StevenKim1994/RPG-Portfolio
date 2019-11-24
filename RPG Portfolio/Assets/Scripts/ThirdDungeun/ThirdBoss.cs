// Author : Steven Kim (Kim Siyon 김시윤)
// E-mail : dev@donga.ac.kr

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;


public class ThirdBoss : MonoBehaviour
{
    [SerializeField] GameObject DropBox;
    [SerializeField] GameObject HitParticle;
    [SerializeField] GameObject flotingtext;

    private Animator anim;
    NavMeshAgent nav;
    Transform Target;
    ManagerSingleton MGR = new ManagerSingleton();
    UISingleton UI = new UISingleton();
    private float hP = 100f;
    private float mP = 100f;
    private int state = 0;
    // Start is called before the first frame update
    void Start()
    {

        anim = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
        nav.speed = 1f;
        Target = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        this.anim.SetTrigger("Attack");
        if(hP <= 0f )
        {
            if(this.state == 0)
            { 
            state = 1; // 죽음
            Instantiate(DropBox, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 10f, this.gameObject.transform.position.z), Quaternion.identity);
            StartCoroutine(Die());

            }
        }
        else if (state == 0) // 살아있을떄만
        {
          
                this.anim.SetBool("Walk", true);
                transform.LookAt(Target);
                nav.destination = Target.position;
                nav.enabled = true;
            if(Vector3.Distance(this.gameObject.transform.position, this.Target.gameObject.transform.position) <=3f)
            {
                nav.enabled = false;
                this.anim.SetBool("Walk",false);
                this.anim.SetTrigger("Attack");
                if(this.Target.transform.GetComponent<Player>().cck == false)
                { 
                    MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Save_HP(MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Load_HP()-10f);
                this.Target.transform.GetComponent<Player>().Attacked();
                }
            }
            else
            {
                this.anim.SetBool("Walk", true);
                nav.enabled = true;
            }

        }
    }
    private void OnTriggerEnter(Collider col) // 여기 계속 수정해야함 19.11.14;
    {
        if (col.gameObject.tag == "User_Weapon")
        {
            Instantiate(HitParticle, this.gameObject.transform.localPosition, this.gameObject.transform.localRotation);
            anim.SetTrigger("Hurt");
            Set_HP(Get_HP() - 10f);
            Debug.Log(Get_HP());
            GameObject txtclone = Instantiate(flotingtext, Camera.main.WorldToScreenPoint(this.gameObject.transform.position), Quaternion.Euler(Vector3.zero));
            txtclone.GetComponent<FloatingText>().text.text = "-10";
            txtclone.transform.SetParent(GameObject.Find("UI").transform);
            int random = UnityEngine.Random.Range(0, 2) + 1;
            Debug.Log(random);
            if (random == 1) //일정확률로 스턴걸리는 기능 추가하기...
            {
                StartCoroutine(Stun());
            }
        }
        if (col.gameObject.tag == "User_Bullet")
        {

            
                Instantiate(HitParticle, this.gameObject.transform);

            anim.SetTrigger("Hurt");
            Set_HP(Get_HP() - 5f);
            GameObject txtclone = Instantiate(flotingtext, Camera.main.WorldToScreenPoint(this.gameObject.transform.position), Quaternion.Euler(Vector3.zero));
            txtclone.GetComponent<FloatingText>().text.text = "-5";
            txtclone.transform.SetParent(GameObject.Find("UI").transform);
            Destroy(col.gameObject);
        }

    }

    IEnumerator Stun()
    {
        Debug.Log("스턴!");
        anim.SetBool("Stun", true);
        GameObject txtclone = Instantiate(flotingtext, Camera.main.WorldToScreenPoint(this.gameObject.transform.position), Quaternion.Euler(Vector3.zero));
        txtclone.GetComponent<FloatingText>().text.text = "스턴!!!";
        txtclone.transform.SetParent(GameObject.Find("UI").transform);
        nav.enabled = false;
        state = 3;
        yield return new WaitForSeconds(5f);
        anim.SetBool("Stun", false);
        state = 0;
        yield break;
    }


    public void Set_HP(float _in)
    {
        hP = _in;
    }

    public float Get_HP()
    {
        return hP;
    }
    private void OnMouseDown()
    {
        MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Set_Target(this.gameObject);
    }

    private void OnMouseOver()
    {
        MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Interface).transform.GetComponent<InterfaceManagerScript>().AttackCursor();
    }

    private void OnMouseExit()
    {
        MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Interface).transform.GetComponent<InterfaceManagerScript>().DefaultCursor();
    }

    IEnumerator Die()
    {
        this.anim.SetBool("Dead", true);

        yield return new WaitForSeconds(3f);

        Destroy(this.gameObject);
        yield break;
    }
}

