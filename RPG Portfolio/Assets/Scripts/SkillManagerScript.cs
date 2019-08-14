using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject Player;

    [SerializeField]
    Sprite[] SKILL_ICON = new Sprite[12];

    [SerializeField]
    Sprite[] Potion_ICON = new Sprite[12];

    bool isAttack = false;

    int count = 0;
    struct Skill
    {
        Sprite SkillSprite;
        int Num;
        string SkillName;
        float Damage;
        float Speed;
        int Duration;
    }

    
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        InputKey();
    }

  
    void InputKey()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Player.gameObject.transform.GetComponent<Animator>().SetBool("Idle", false);
            Player.gameObject.transform.GetComponent<Animator>().SetTrigger("MeleeAttackStart");
            Attack();
           // Player.gameObject.transform.GetComponent<Animator>().SetBool("MeleeAttack", true);
        }

        else if(!(Input.GetKey(KeyCode.Alpha1)))
        {
            Player.gameObject.transform.GetComponent<Animator>().SetBool("MeleeAttack", false);
        }

        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            Player.gameObject.transform.GetComponent<Animator>().SetTrigger("StrongBuffSkill");
        }
    }

    void Attack()
    {
        if(isAttack == false)
        {

            Player.gameObject.transform.GetComponent<Animator>().SetBool("MeleeAttack", true);
            count++; 
        }
        else if(count == 3)
        {
            Player.gameObject.transform.GetComponent<Animator>().SetBool("MeleeAttack", false);
            Player.gameObject.transform.GetComponent<Animator>().SetBool("Idle", true);
            count = 0;
        }
    }

    public void Set_Player(GameObject _in)
    {
        Player = _in;
    }

}
