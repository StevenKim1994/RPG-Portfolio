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
    
   
    struct Skill // Pirate 스킬 정보 구조체
    {
        Sprite SkillSprite;
        int Num;
        string SkillName;
        float Damage;
        float Speed;
        int Duration;

        public Skill(Sprite _sprite,int _num, string _skillName, float _damage, float _speed, int _duration)
        {
            this.SkillSprite = _sprite;
            this.Num = _num;
            this.SkillName = _skillName;
            this.Damage = _damage;
            this.Speed = _speed;
            this.Duration = _duration;
        }

    }

    [SerializeField] private Sprite[] SkillSprite = new Sprite[10];
    [SerializeField] GameObject Hitcanvas;
    delegate void RL();
    delegate void RR();
    FollowCamera FC = new FollowCamera();
    RL rl;
    RR rr;

    private GameObject GameMgr;
    private List<Skill> Buff = new List<Skill>();
    private Animator Anim;
    private bool MoveFlag = false;

    private int STR =0;
    private int DEX = 0;
    private int INT =0;
    private float Armor =0;
    private float Damage = 0;
    private string Name = "0";

    private bool Jump = false;
    private bool isAttack = false;
    private int count = 0;

    float HP = 1000000f;
    float MP = 50000f;

    float Rotate = 0.0f;
    float x_pos = 0.0f;
    float y_pos = 0.0f;

    bool DoubleKey = false;
    public int state = 0; // 0 : idle 1 : attack 2 : hurt
    float CountRight = 0.0f;
    float CountLeft = 0.0f;

    GameObject Target;

    [SerializeField]
    GameObject Target_Frame;

    [SerializeField] private GameObject HitEffect;
    [SerializeField] private GameObject PowerUpSkillEffect;

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
        
        if(Target != null)
        {
            Target_Frame.SetActive(true);
        }
        MoveCtrl(); // 이동처리
        if(MoveFlag == true)
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
            Debug.Log("보스의 파이어볼 충돌감지!");
            Anim.SetTrigger("Attacked");
            StartCoroutine(FireBallHit());
            Destroy(col.gameObject);
            Instantiate(Hitcanvas);
            
        }

        
    }

   
    void InputKey() // 스킬처리 부분
    {
        if (this.gameObject.transform.name == "Player(Pirate)(Clone)") // 캐릭터가 해적일 경우...
        {
            
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
              
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

                
                Buff.Add(new Skill(SkillSprite[1], 1, "StrongBuffSkill", 0, 0, 10));
                this.gameObject.transform.GetComponent<Animator>().SetTrigger("StrongBuffSkill");

                StartCoroutine(Skill2());
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

}