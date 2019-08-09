using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator Anim;
    public float MoveSpeed;
    public float RotSpeed;
    bool MoveFlag = false;

    int STR;
    int DEX;
    int INT;

    float Armor;
    float Damage;
    float HP;
    float MP;

    GameObject Target;

    [SerializeField]
    GameObject Target_Frame;

    public void Set_Target(GameObject _in)
    {
        Target = _in;
    }
    public GameObject Get_Target()
    {
        return Target;
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
           
            MoveFlag = true;
            this.transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);

            // 일정 앵글 넘어서면 카메라도 움직이게 해야함
        }
     

        if (Input.GetKey(KeyCode.A))
        {
        
            MoveFlag = true;
            this.transform.Translate(Vector3.left * MoveSpeed * Time.deltaTime);

            // 일정 앵글 넘어서면 카메라도 움직이게 해야함
        }


        if (Input.GetKey(KeyCode.S))
        {
     
            MoveFlag = true;
            this.transform.Translate(Vector3.back * MoveSpeed * Time.deltaTime);

            // 일정 앵글 넘어서면 카메라도 움직이게 해야함
        }


        if (Input.GetKey(KeyCode.D))
        {
          
            MoveFlag = true;
            this.transform.Translate(Vector3.right * MoveSpeed * Time.deltaTime);

            // 일정 앵글 넘어서면 카메라도 움직이게 해야함
        }

    }

}
