// Author : Steven Kim (Kim Siyon 김시윤)
// E-mail : dev@donga.ac.kr
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.XR;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    delegate Vector3 ReturnOldPosition();
    delegate String ReturnOldScene();

    private ReturnOldPosition ReOldP;
    [SerializeField] GameObject bb;
    [SerializeField] GameObject floatingtext; // 닉네임 직업 출력할 플로팅 텍스트
    [SerializeField] GameObject Bullet;
    [SerializeField] GameObject BulletPosition;
    [SerializeField] private Sprite[] SkillSprite = new Sprite[10];
    [SerializeField] GameObject Hitcanvas;
    [SerializeField] GameObject Minimapcam;
    [SerializeField] GameObject FinalSkillEffect;

    [SerializeField] GameObject Weapon;
    delegate void RL();
    delegate void RR();
    FollowCamera FC = new FollowCamera();
    RL rl;
    RR rr;
    ManagerSingleton MGR = new ManagerSingleton();
    UISingleton UI = new UISingleton();
    private GameObject GameMgr;
    private Animator Anim;
    private bool MoveFlag = false;

    public bool cck = false;
    private int STR =0;
    private int DEX = 0;
    private int INT =0;
    private float Armor =0;
    private float Damage = 0;
    private string Name = "0";

    private bool Jump = false;
    private bool isAttack = false;
    private int count = 0;

    float HP = 100f;
    float MP = 100f;
    float timer;
    float waittime;
    GameObject temp;
    public int HPPo = 0;
    public int MPPo = 0;
    float Rotate = 0.0f;
    float x_pos = 0.0f;
    float y_pos = 0.0f;

    bool DoubleKey = false;
    public int state = 0; // 0 : idle 1 : attack 2 : hurt 3: dead
    float CountRight = 0.0f;
    float CountLeft = 0.0f;

    GameObject Target;

    [SerializeField]
    GameObject Target_Frame;

    [SerializeField] private GameObject HitEffect;
    [SerializeField] private GameObject PowerUpSkillEffect;
    [SerializeField] private GameObject PowerUpSkillEfeect2;
    [SerializeField] private GameObject FireballHitEffect;

    public float MoveSpeed;
    public float RotateSpeed = 100.0f;

    public void Set_Name(string _in)
    {
        Name = _in;
    }

    public string Get_Name()
    {
        return Name;
    }
    public void Set_Target(GameObject _in)
    {
        this.Target = _in;
    }
    public GameObject Get_Target()
    {
        return this.Target;
    }

    public float Get_Armor()
    {
        return Armor;
    }

    public float Get_Damage()
    {
        return Damage;
    }

    public float Get_HP()
    {
        return HP;
    }

    public float Get_MP()
    {
        return MP;
    }

    public int Get_STR()
    {
        return STR;
    }

    public int Get_DEX()
    {
        return DEX;
    }

    public int Get_INT()
    {
        return INT;
    }

    public void Set_Armor(float _in)
    {
        Armor = _in;
    }
    public void Set_Damage(float _in)
    {
        Damage = _in;
    }

    public void Set_HP(float _in)
    {
        HP = _in;
    }

    public void Set_MP(float _in)
    {
        MP = _in;
    }

    public void Set_STR(int _in)
    {
        STR = _in;
    }

    public void Set_DEX(int _in)
    {
        DEX = _in;
    }

    public void Set_INT(int _in)
    {
        INT = _in;
    }
    // Start is called before the first frame update
    void Start()
    {

        bb = UI.Get_Instance().transform.GetChild(3).gameObject;
        ReturnOldScene d_s = new GameManagerScript().Get_OldScene;
        ReturnOldPosition d_p = new PlayerManagerScripts().Get_OldPosition;


        if (d_s() != null)
        {
            if (d_s() != null)
            {
                if (d_s() != SceneManager.GetActiveScene().ToString() || d_s() != null)
                {
                    this.transform.position = d_p();
                }
            }
        }

        Vector3 angles = this.transform.eulerAngles;
        Rotate = this.transform.forward.x;
        Anim = this.GetComponent<Animator>();

        if(Target_Frame != null)
        Target_Frame.SetActive(false);

        MoveFlag = false;

        if (this.gameObject.transform.name == "Pirate") // 나중에 다른 캐릭터 추가되면 리소스로드로 Sprite 바꾸는거 추가... 19.08.15
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        if(MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Load_HP() <=0) // 죽는다면
        {
            state = 4;
            Anim.SetBool("Dead", true);
            UI.Get_Instance().transform.GetChild(13).gameObject.SetActive(true);
        }
        else
        {
            state = 0;
            Anim.SetBool("Dead", false);
            UI.Get_Instance().transform.GetChild(13).gameObject.SetActive(false);

        }

        if (state != 4)
        {
            if (Anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.atk01") || Anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.atk02") || Anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.atk03"))
            {
                Weapon.transform.GetComponent<TrailRenderer>().enabled = true;
            }
            // 무기 트레일 기능 온
            else
            {
                Weapon.transform.GetComponent<TrailRenderer>().enabled = false;
            }
            // 무기 트레일 기능 오프
            /* timer += Time.deltaTime;

             if (timer > waittime)
             {
                 if(MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Load_MP()< 100)
                     MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Save_MP(MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Load_MP() + 1);
             }*/ //마나리젠


            if (Target != null)
            {
                Target_Frame.SetActive(true);
            }
            MoveCtrl(); // 이동처리
            if (MoveFlag == true)
            {
                Anim.SetBool("Walking", true);
                Anim.SetBool("Idle", false);

            }
            else
            {
                Anim.SetBool("Walking", false);
                Anim.SetBool("Idle", true);
            }

            InputKey(); // 스킬처리


        }
    }
    void MoveCtrl()
    {
        MoveFlag = false;
        if(Input.GetKey(KeyCode.W))
        {

            if (DoubleKey == false)
            {
                MoveFlag = true;
                this.transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);
            }



        }


        if (Input.GetKey(KeyCode.A))
        {

            CountRight = 0.0f;
            CountLeft += 1.0f;
            if (CountLeft >= 10f)
            {
                CountLeft = 0.0f;
            }
            //MoveFlag = true;
            //this.transform.Translate(Vector3.left * MoveSpeed * Time.deltaTime);
            rl();

            Rotate += 0.5f;
            Rotate += CountLeft + RotateSpeed * 0.015f;



            this.transform.rotation = Quaternion.Euler(0, -Rotate, 0);


        }
        else if ((Input.GetKey(KeyCode.A)) && (Input.GetKey(KeyCode.W)))
        {

            DoubleKey = true;
            MoveFlag = true;
            this.transform.Translate(Vector3.left * MoveSpeed * Time.deltaTime);
            this.transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);
        }
        else
        {
            DoubleKey = false;
        }


        if (Input.GetKey(KeyCode.S))
        {

            MoveFlag = true;
            this.transform.Translate(Vector3.back * MoveSpeed/2.0f * Time.deltaTime);


        }


        if (Input.GetKey(KeyCode.D))
        {
            rr();
            CountLeft = 0.0f;
            CountRight += 1.0f;
            if(CountRight >= 10f)
            {
                CountRight = 0.0f;
            }

            Rotate += 0.5f;
            Rotate += CountRight + RotateSpeed * 0.015f;


            this.transform.rotation = Quaternion.Euler(0, Rotate, 0);



            // 일정 앵글 넘어서면 카메라도 움직이게 해야함
        }
        else if ((Input.GetKey(KeyCode.D)) && (Input.GetKey(KeyCode.W)))
        {
            DoubleKey = true;
            MoveFlag = true;
            this.transform.Translate(Vector3.right * MoveSpeed * Time.deltaTime);
            this.transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);
        }
        else
        {
            DoubleKey = false;
        }

        if(Input.GetKey(KeyCode.Space)) // User 캐릭터 점프...
        {
            this.transform.Translate(Vector3.up * (MoveSpeed+1) * Time.deltaTime);
            Jump = true;
            if(this.transform.position.y <= 25f)
            {
                return;
            }

            if(this.transform.position.y == 0.5)
            {
                Jump = false;
            }
        }
    }


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Monster_Weapon")
        {
            Debug.Log("몬스터의 공격감지!");

            //데미지연산해서 Player의 체력계산 추가하기
            Destroy(col.gameObject);
            Instantiate(HitEffect, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), transform.rotation); // 타격 피이펙트 생성...
            Anim.SetTrigger("Attacked");//Player의 타격 애니메이션 재생
            Instantiate(Hitcanvas);

        }

        if (col.gameObject.tag == "Enermy_Fireball")
        {

            Anim.SetTrigger("Attacked");
            MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Save_HP(MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Load_HP() - 5);
            StartCoroutine(FireBallHit());
            Destroy(col.gameObject);
            Instantiate(Hitcanvas);
           
        }


    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Monster_Weapon")
        {
            Destroy(other.gameObject);
            Instantiate(
                HitEffect,
                new Vector3(transform.position.x, transform.position.y + 1, transform.position.z),
                transform.rotation); // 타격 피이펙트 생성...
            Anim.SetTrigger("Attacked"); //Player의 타격 애니메이션 재생
            Instantiate(Hitcanvas);
        }


    }

    void InputKey() // 스킬처리 부분
    {
        if (this.gameObject.transform.name == "Player(Pirate)(Clone)") // 캐릭터가 해적일 경우...
        {

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {


                    Weapon.transform.GetComponent<TrailRenderer>().enabled = true;

                this.gameObject.transform.GetComponent<Animator>().SetBool("Idle", false);
                this.gameObject.transform.GetComponent<Animator>().SetTrigger("MeleeAttackStart");
                Attack();

            }

            else if (!(Input.GetKey(KeyCode.Alpha1)))
            {


                this.gameObject.transform.GetComponent<Animator>().SetBool("MeleeAttack", false);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {

                if (MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Load_MP() >= 20) // 플레이어의 마나가 20이상일때
                {
                    bb.transform.GetComponent<Buffbar>().BuffOn(1); // 버프창에 아이콘추가함.
                    this.gameObject.transform.GetComponent<Animator>().SetTrigger("StrongBuffSkill");
                    MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Save_MP(MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Load_MP() - 20);
                    StartCoroutine(Skill2());
                    StartCoroutine(SpeedUP());
                }

            }

            if(Input.GetKeyDown(KeyCode.Alpha3))
            {
                if (MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Load_MP() >= 10) // 플레이어의 마나가 10이상일때
                {
                    if (MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Get_Target() != null) // 타겟이 지정되어있을때만
                    {

                        this.gameObject.transform.GetComponent<Animator>().SetTrigger("GunFireSkill");
                        MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Save_MP(MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Load_MP() - 10);
                        Instantiate(Bullet, BulletPosition.transform);
                    }
                }
            }

            if(Input.GetKeyDown(KeyCode.Alpha4))
            {
                if(MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Load_MP() >= 50) // 플레이어의 마나가 50이상일때
                {
                    if (MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Get_Target() != null) // 타겟이 지정되어있을때만
                    {

                        this.gameObject.transform.GetComponent<Animator>().SetTrigger("GunFireSkill");
                        MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Save_MP(MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Load_MP() - 50);

                        StartCoroutine(FinalSkill());
                    }
                }
            }

            if(Input.GetKeyDown(KeyCode.Alpha5))
            {
                if (MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Load_MP() >= 10)
                {
                    MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Save_MP(MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Load_MP() - 10);
                    StartCoroutine(PowerUPSkill2());
                    bb.transform.GetComponent<Buffbar>().BuffOn(2);
                }
            }

            if(Input.GetKeyDown(KeyCode.Alpha9))
            {
                Debug.Log("HP물약사용!");
                if (MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Get_HPPo() > 0)
                {

                    MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Save_HP(MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Load_HP()+5f);
                    if (MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Load_HP() >= 100)
                    {
                        MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Save_HP(100);
                    }
                    MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Set_HPPo(MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Get_HPPo() - 1);
                    MGR.Get_instance().gameObject.transform.GetChild((int)Enum.Managerlist.Interface).transform.GetComponent<InterfaceManagerScript>().HPPoSet();
                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                Debug.Log("MP물약사용!");
                if (MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Get_MPPo() > 0)
                {
                    MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Save_MP(MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Load_MP() + 5f);
                    if(MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Load_MP() >=100)
                    {
                        MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Save_MP(100);
                    }
                    MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Set_MPPo(MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Get_MPPo() - 1);
                    MGR.Get_instance().gameObject.transform.GetChild((int)Enum.Managerlist.Interface).transform.GetComponent<InterfaceManagerScript>().MPPoSet();
                }
            }


        }

        void Attack()
        {
            if (isAttack == false)
            {

                this.gameObject.transform.GetComponent<Animator>().SetBool("MeleeAttack", true);
                count++;
            }
            else if (count == 3)
            {
                this.gameObject.transform.GetComponent<Animator>().SetBool("MeleeAttack", false);
                this.gameObject.transform.GetComponent<Animator>().SetBool("Idle", true);
                count = 0;
            }
            state = 0;
        }
    }

    public Animator get_state()
    {
        return Anim;
    }
    IEnumerator FireBallHit()
    {
        GameObject temp = Instantiate(FireballHitEffect, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), transform.rotation);
        yield return new WaitForSeconds(1f);
        Destroy(temp);
        yield break;
    }


    IEnumerator Skill2()
    {
        GameObject temp = Instantiate(PowerUpSkillEffect, this.gameObject.transform.localPosition, this.gameObject.transform.rotation);
        temp.transform.rotation = Quaternion.Euler(-90, 0, 0);

        yield return new WaitForSeconds(2f);
        Destroy(temp);
        yield break;
    }

    IEnumerator SpeedUP()
    {
        this.gameObject.transform.GetComponent<TrailRenderer>().enabled = true;
        MoveSpeed += 3f;

        yield return new WaitForSeconds(10f);
        this.gameObject.transform.GetComponent<TrailRenderer>().enabled = false;
        MoveSpeed -= 3f;
        yield break;
    }

    IEnumerator FinalSkill()
    {
        GameObject temp = Instantiate(FinalSkillEffect, MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Get_Target().transform.position, MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Get_Target().transform.rotation);
        if (SceneManager.GetActiveScene().name == "FirstDungeonScene")
        {
            MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Get_Target().transform.GetComponent<FirstBoss>().Set_HP(MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Get_Target().transform.GetComponent<FirstBoss>().Get_HP() - 50f);
        }

        else if (SceneManager.GetActiveScene().name == "SecondDungeonScene")
        {
            MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Get_Target().transform.GetComponent<SecondBoss>().Set_HP(MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Get_Target().transform.GetComponent<SecondBoss>().Get_HP() - 50f);
        }

        else if (SceneManager.GetActiveScene().name == "ThirdDungeonScene")
        {
            MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Get_Target().transform.GetComponent<ThirdBoss>().Set_HP(MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Get_Target().transform.GetComponent<ThirdBoss>().Get_HP() - 50f);
        }
        yield return new WaitForSeconds(5f);

        Destroy(temp);
        yield break;
    }

    IEnumerator PowerUPSkill2()
    {
        GameObject temp = Instantiate(PowerUpSkillEfeect2, this.gameObject.transform.localPosition, this.gameObject.transform.localRotation);
        yield return new WaitForSeconds(3f);

        Destroy(temp);
        yield break;

    }

    public void Attacked()
    {
        if(this.cck==false)
        StartCoroutine(Atk1());
    }

    IEnumerator Atk1()
    {
        cck = true;
        Instantiate(Hitcanvas);
        Anim.SetTrigger("Attacked");
        yield return new WaitForSeconds(3.5f);
        cck = false;
        yield break;
    }
}