using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
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

    [SerializeField] private Sprite[] SkillSprite = new Sprite[10]; // 나중에 캐릭터 추가되면 리소스로드로 불러올 예정 19.08.15

    private List<Skill> Buff = new List<Skill>();
    private Animator Anim;
    private bool MoveFlag = false;

    private int STR;
    private int DEX;
    private int INT;
    private float Armor;
    private float Damage;
    private string Name;

    private bool Jump = false;
    private bool isAttack = false;
    private int count = 0;

    float HP;
    float MP;

    float Rotate = 0.0f;
    float x_pos = 0.0f;
    float y_pos = 0.0f;

    bool DoubleKey = false;
    float CountRight = 0.0f;
    float CountLeft = 0.0f;

    GameObject Target;

    [SerializeField]
    GameObject Target_Frame;

    [SerializeField] private GameObject HitEffect;

    [SerializeField] private GameObject PowerUpSkillEffect;

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


            Rotate += 0.5f;
            Rotate += CountLeft + RotateSpeed * 0.015f;

            

            this.transform.rotation = Quaternion.Euler(0, -Rotate, 0);

            //if(count > 5.0f)
            //{
            //    MoveFlag = true;
            //    this.transform.Translate(Vector3.left * MoveSpeed * Time.deltaTime) ;
            //}
            // 일정 앵글 넘어서면 카메라도 움직이게 해야함
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

            // 일정 앵글 넘어서면 카메라도 움직이게 해야함
        }


        if (Input.GetKey(KeyCode.D))
        {
          
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



    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enermy_Weapon")
        {
            Instantiate(HitEffect, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), transform.rotation);
            Anim.SetTrigger("Attacked");

        }
    }

    void InputKey() // 스킬처리 부분
    {
        if (this.gameObject.transform.name == "Pirate") // 캐릭터가 해적일 경우...
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                this.gameObject.transform.GetComponent<Animator>().SetBool("Idle", false);
                this.gameObject.transform.GetComponent<Animator>().SetTrigger("MeleeAttackStart");
                Attack();
                // Player.gameObject.transform.GetComponent<Animator>().SetBool("MeleeAttack", true);
            }

            else if (!(Input.GetKey(KeyCode.Alpha1)))
            {
                this.gameObject.transform.GetComponent<Animator>().SetBool("MeleeAttack", false);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {

                Buff.Add(new Skill(SkillSprite[1], 1, "StrongBuffSkill", 0, 0, 10));
                this.gameObject.transform.GetComponent<Animator>().SetTrigger("StrongBuffSkill");
                Instantiate(PowerUpSkillEffect, this.gameObject.transform);
                
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
        }
    }
}
