using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonBoss : MonoBehaviour
{

    [SerializeField] float hP;
    [SerializeField] float mP;
    private int state; // 보스의 현재 상태 0 이면 초기 페이지 1이면 화남 페이지 2면 광폭화 페이지... 

    [SerializeField] private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        state = 0;
        hP = 10000f;
        mP = 10000f;


    }

    // Update is called once per frame
    void Update()
    {
        if (hP <= hP / 2)
            state = 1;
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
}
