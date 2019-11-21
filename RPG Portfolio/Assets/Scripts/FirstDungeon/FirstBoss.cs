using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class FirstBoss : MonoBehaviour
{

    [SerializeField] float hP;
    [SerializeField] float mP;
    [SerializeField] float damage;
    [SerializeField] private GameObject HitParticle;
    [SerializeField] GameObject DeadParticle;
    [SerializeField] private GameObject Fireball;
    [SerializeField] private GameObject Fireball_initPosition;
    [SerializeField] private GameObject CurseWall;
    [SerializeField] private GameObject Hiteffect_initPosition;
    [SerializeField] Transform position;
    [SerializeField] private NavMeshAgent nav;
    [SerializeField] private Transform target; // 유저의 좌표 값이 타겟이 됨...
    [SerializeField] private Animator anim;
    [SerializeField] GameObject Range;
    [SerializeField] GameObject Attack;
    [SerializeField] GameObject floatingtext;
    [SerializeField] GameObject floatingcanvas;
    [SerializeField] GameObject DropBox;
    GameObject skilltemp;
    bool cocheck = false;
    Vector3 original_position;
    int count = 0; // 근처에 플레이어가 머물러 있는 시간...
    private int state; // 보스의 현재 상태 0 이면 초기 페이지 1이면 화남 페이지 2면 광폭화 페이지...
    private float timer = 0.0f;
    private int waitTime;
    bool death = false;
    private int ballcount = 0;
    ManagerSingleton MGR = new ManagerSingleton();

    private float TimeLeft = 1.0f;
    private float nextTime = 0.0f;
    Transform temp;
    void Start()
    {
        temp = Hiteffect_initPosition.transform;
        temp.transform.Translate(0, -10, 0);
        waitTime = 1;
        anim = this.gameObject.transform.GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        nav = this.gameObject.transform.GetComponent<NavMeshAgent>();
        state = 0;

        original_position = this.gameObject.transform.position;
        if(this.gameObject.transform.name == "FirstBoss")
        InvokeRepeating("ShotFireball",2.5f,2.5f);
    }

    // Update is called once per frame
    void Update()
    {

        if (hP <= 0)
        {
            timer += Time.deltaTime;
            Instantiate(DeadParticle, this.gameObject.transform);// 사망 이펙트

            if (this.gameObject.transform.name == "FirstBoss")
            {
                if(death == false)
                Instantiate(DropBox, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y+10f, this.gameObject.transform.position.z), Quaternion.identity); // 아이템박드드랍

                death = true;
                MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Game).transform.GetComponent<GameManagerScript>().Set_ClearInfo(1); // 게임매니저 클리어 정보 설정
            }

            if (timer > waitTime)
            {
                MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Inventory).GetComponent<InventoryManagerScript>().SetGold(MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Inventory).GetComponent<InventoryManagerScript>().GetGold() + 100); // 보스 킬시 유저의 인벤토리에 골드가 100+
                Destroy(skilltemp);
                Destroy(this.gameObject);
            }
        }

        if (hP <= hP / 2)
        {
            state = 1; // 화남페이지
            damage += 20f; // 화가 나면 데미지 20상승

        }

        if (Vector3.Distance(this.gameObject.transform.position, target.transform.position) <= 10f)
        {
            if (this.gameObject.transform.name == "FirstBoss")
                CancelInvoke("ShotFireball"); // 가까이 도달하면 보스는 더이상 원거리 공격을 하지 않음.

            if (Time.time > nextTime) // 보스 가까이에 있는 시간 카운트...
            {
                //Debug.Log(count);
                count++;
                nextTime = Time.time + TimeLeft;

            }
            if (this.gameObject.transform.name == "FirstBoss")
            {
                if (count >= 10) //보스와 플레이어와 거리가 가까운채로 10초이상일때 보스의 특별한 스킬발동...
                {
                    count = 0;
                    Debug.Log("발동!!!");
                    StartCoroutine(SpellCurseWall());//Instantiate(CurseWall, position.transform.localPosition, position.transform.rotation); //보스의 특정 광역스킬 발동
                }
            }

            nav.enabled = true;
            //Debug.Log("가까움");
            this.transform.LookAt(target);

            anim.SetBool("Running", true);
            nav.SetDestination(target.transform.position); // 따라가기...

            if(Vector3.Distance(this.gameObject.transform.position, target.transform.position) <6f)
            {
                nav.enabled = false;
                anim.SetTrigger("Skill1");
                if (cocheck == false)
                {
                    cocheck = true;
                    StartCoroutine(AttackCall());
                }

            }
        }
        else
        {
            count = 0; // 거리가 멀어지면 근접해 있는 시간 0으로 초기화함.
        }



    }
    IEnumerator SpellCurseWall() // 근접해 있을때 특정시간마다 광역 스킬 사용 코루틴
    {

       skilltemp = Instantiate(CurseWall, position.transform.localPosition, position.transform.rotation); //보스의 특정 광역스킬 발동
        skilltemp.transform.rotation = Quaternion.Euler(-90, 0, 0);

        yield return new WaitForSeconds(5f);
        Destroy(skilltemp);
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

    public void Set_MP(float _in)
    {
        mP = _in;
    }

    public float Get_MP()
    {
        return mP;
    }

    public void Skill1()
    {

    }

    public void Skill2()
    {

    }

    public void Skill3()
    {

    }


    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "User_Weapon")
        {

           // if (col.gameObject.transform.root.GetComponent<Player>().get_state().GetCurrentAnimatorStateInfo(0).IsName("Base Layer.atk01") || col.gameObject.transform.root.GetComponent<Player>().get_state().GetCurrentAnimatorStateInfo(0).IsName("Base Layer.atk02") || col.gameObject.transform.root.GetComponent<Player>().get_state().GetCurrentAnimatorStateInfo(0).IsName("Base Layer.atk03"))
           // {
                if(this.gameObject.name == "FirstBoss")
                    Instantiate(HitParticle, temp);
                else
                 Instantiate(HitParticle, this.gameObject.transform);

                anim.SetTrigger("Hurt");
                Set_HP(Get_HP() - 10f);
                Debug.Log(Get_HP());
                GameObject txtclone = Instantiate(floatingtext, Camera.main.WorldToScreenPoint(this.gameObject.transform.position), Quaternion.Euler(Vector3.zero));
                txtclone.GetComponent<FloatingText>().text.text = "-10";
                txtclone.transform.SetParent(GameObject.Find("UI").transform);




           // }
        }

        if(col.gameObject.tag == "User_Bullet")
        {

            if (this.gameObject.name == "FirstBoss")
                Instantiate(HitParticle, temp);
            else
                Instantiate(HitParticle, this.gameObject.transform);

            anim.SetTrigger("Hurt");
            Set_HP(Get_HP() - 5f);
            GameObject txtclone = Instantiate(floatingtext, Camera.main.WorldToScreenPoint(this.gameObject.transform.position), Quaternion.Euler(Vector3.zero));
            txtclone.GetComponent<FloatingText>().text.text = "-5";
            txtclone.transform.SetParent(GameObject.Find("UI").transform);
            Destroy(col.gameObject);
        }
    }

    private void ShotFireball() // 원거리 공격
    {

        this.transform.LookAt(target);
        anim.SetTrigger("Skill1");
        Instantiate(Fireball, Fireball_initPosition.transform);
        ballcount++;
    }

    IEnumerator AttackCall()
    {
        GameObject temp = Instantiate(Attack, Range.transform);

        yield return new WaitForSeconds(5f);
        cocheck = false;
        Destroy(temp);
        yield break;

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
}
