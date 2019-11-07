using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
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
    private int state; // 보스의 현재 상태 0 이면 초기 페이지 1이면 화남 페이지 2면 광폭화 페이지... 

    private float timer = 0.0f;
    private int waitTime;
    [SerializeField] Transform position;
    [SerializeField] private NavMeshAgent nav;
    [SerializeField] private Transform target; // 유저의 좌표 값이 타겟이 됨...
    [SerializeField] private Animator anim;
    Vector3 original_position;
    int count = 0; // 근처에 플레이어가 머물러 있는 시간...
    private int ballcount = 0;
    ManagerSingleton MGR = new ManagerSingleton();

    private float TimeLeft = 1.0f;
    private float nextTime = 0.0f;

    void Start()
    {
        waitTime = 1;
        anim = this.gameObject.transform.GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        nav = this.gameObject.transform.GetComponent<NavMeshAgent>();
        state = 0;
      

        original_position = this.gameObject.transform.position;

        InvokeRepeating("ShotFireball",2.5f,2.5f);
    }

    // Update is called once per frame
    void Update()
    {

       

        
        if (hP <= 0)
        {
            timer += Time.deltaTime;
            Instantiate(DeadParticle, this.gameObject.transform);// 사망 이펙트
            //MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Inventory).GetComponent<InventoryManagerScript>()
            if(timer > waitTime)
            Destroy(this.gameObject);
        }
      
        if (hP <= hP / 2)
        {
            state = 1; // 화남페이지
            damage += 20f; // 화가 나면 데미지 20상승

        }

        if (Vector3.Distance(this.gameObject.transform.position, target.transform.position) <= 10f)
        {
            if (Time.time > nextTime)
            {
                //Debug.Log(count);
                count++;
                nextTime = Time.time + TimeLeft;

            }

            if (count >= 10) //보스와 플레이어와 거리가 가까운채로 10초이상일때 보스의 특별한 스킬발동...
            {
                count = 0;
                Debug.Log("발동!!!");
                StartCoroutine(SpellCurseWall());//Instantiate(CurseWall, position.transform.localPosition, position.transform.rotation); //보스의 특정 광역스킬 발동
            }
            CancelInvoke("ShotFireball");
            nav.enabled = true;
            //Debug.Log("가까움");
            this.transform.LookAt(target);
           
            anim.SetBool("Running", true);
            nav.SetDestination(target.transform.position); // 따라가기...
            
            if(Vector3.Distance(this.gameObject.transform.position, target.transform.position) <6f)
            {
                nav.enabled = false;
                
                // 공격 트리거가 실행될때는 이게 호출이 되면 안됨.
                anim.SetTrigger("Skill1");
            }



        }
        
        
       
    }
    IEnumerator SpellCurseWall()
    {
        
        GameObject temp = Instantiate(CurseWall, position.transform.localPosition, position.transform.rotation); //보스의 특정 광역스킬 발동
        temp.transform.rotation = Quaternion.Euler(-90, 0, 0);
        
        yield return new WaitForSeconds(5f);
        Destroy(temp);
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


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "User_Weapon")
        {
            Debug.Log("타격타격!");
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "User_Weapon")
        {
            Instantiate(HitParticle,col.transform);
            Debug.Log("타격타격@");
            anim.SetTrigger("Hurt");
            Set_HP(Get_HP() - 10f);
            Debug.Log(Get_HP());
        }
    }

    private void ShotFireball()
    {

        this.transform.LookAt(target);
        anim.SetTrigger("Skill1");
        Instantiate(Fireball, Fireball_initPosition.transform);
        ballcount++;
    }

}
