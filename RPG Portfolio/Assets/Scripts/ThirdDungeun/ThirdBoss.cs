// Author : Steven Kim (Kim Siyon 김시윤)
// E-mail : dev@donga.ac.kr

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityScript.Steps;


public class ThirdBoss : MonoBehaviour
{
    [SerializeField] GameObject DropBox;
    [SerializeField] GameObject HitParticle;
    [SerializeField] GameObject flotingtext;
    [SerializeField] GameObject PlayerHitEffect;
    [SerializeField] GameObject PlayerHitCanvas;

    public Animator anim;

    NavMeshAgent nav;
    Transform Target;
    ManagerSingleton MGR = new ManagerSingleton();
    UISingleton UI = new UISingleton();
    private float hP = 100f;
    private float mP = 100f;
    private int state = 0;
    private bool coroutine_is_running = false;
    private float anim_exittime = 0.8f;
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
      // Debug.Log(Vector3.Distance(this.gameObject.transform.position, this.Target.gameObject.transform.position));
        
        if ( hP > 0)
        {
            nav.speed = 1;
            this.anim.SetBool("Walk",true);

            if (Vector3.Distance(this.gameObject.transform.position, this.Target.gameObject.transform.position) <= 3f) 
            {
             
                nav.speed = 0f;
                this.anim.SetBool("Walk", false);
                this.anim.SetTrigger("Attack");
                // 데미지 처리는 애니메이션 이벤트에서 Attack함수 호출
            }

            else 
            {
                
                nav.speed = 1;
                nav.destination = Target.transform.position;
                nav.enabled = true;
                transform.LookAt(Target);
                this.anim.SetBool("Walk", true);
            }

        }

    }
    private void OnTriggerEnter(Collider col)
    {
  
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

    public IEnumerator Stun()
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
        Instantiate(DropBox, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 10f, this.gameObject.transform.position.z), Quaternion.identity);
        yield return new WaitForSeconds(3f);

        Destroy(this.gameObject);
        yield break;
    }

    public void MeleeAttack()
    {
        float Target_HP = MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Load_HP();
        
        if (Target != null)
        {
            MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Save_HP(Target_HP - 5f);
            Instantiate(PlayerHitEffect, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), transform.rotation); // 타격 피이펙트 생성...
            Target.GetComponent<Animator>().SetTrigger("Attacked");
            MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Save_HP(MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Load_HP() - 5);
          
        }
    }


}

