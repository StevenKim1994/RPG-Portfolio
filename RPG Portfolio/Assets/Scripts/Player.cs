using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator Anim;
    private bool MoveFlag = false;

    private int STR;
    private int DEX;
    private int INT;
    private float Armor;
    private float Damage;
    private string Name;

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
        Target_Frame.SetActive(false);
        MoveFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Target != null)
        {
            Target_Frame.SetActive(true);
        }
        MoveCtrl();
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

    }

}
